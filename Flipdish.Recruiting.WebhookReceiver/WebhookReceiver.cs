using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Flipdish.Recruiting.WebhookReceiver.Models;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public static class WebhookReceiver
    {
        [FunctionName("WebhookReceiver")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                // Deserialize the request body into an OrderCreatedWebhook
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(requestBody);

                // OrderCreatedEvent
                var orderCreatedEvent = orderCreatedWebhook.Body;
 
                // StoreIds
                var storeIds = req.Query["storeId"].ToArray().Select(x => int.TryParse(x, out var storeId) ? storeId : -1);

                // Currency
                Enum.TryParse(typeof(Currency), req.Query["currency"].FirstOrDefault().ToUpper(), out object currencyObject);
                var currency = (Currency)currencyObject;

                // Metadata Key
                var metadataKey = req.Query["metadataKey"].First();

                // To
                var to = req.Query["to"];

                // Setup the EmailRenderer
                // TODO: Looks like EmailRenderer could be static
                var emailRenderer = new EmailRenderer(
                    orderCreatedEvent.Order,
                    orderCreatedEvent.AppId,
                    metadataKey,
                    context.FunctionAppDirectory,
                    log,
                    currency
                 );

                // Render the order email
                // TODO: We should only be calling one service here in the webhook - this is too much business logic
                var emailOrder = emailRenderer.RenderEmailOrder();

                // Send the Email
                // TODO: Untangle EmailService and EmailRenderer
                // TODO: We should only be calling one service here in the webhook - this is too much business logic
                await EmailService.Send("", to, $"New Order #{orderCreatedEvent.Order.OrderId}", emailOrder, emailRenderer._imagesWithNames);

                return new ContentResult { Content = emailOrder, ContentType = "text/html" };
            }
            catch(Exception ex)
            {
                log.LogError(ex, $"Error occured during processing order"); // TODO:  #{orderId}
                throw ex;
            }
        }
    }
}

//  TODO: This business logic needs moving to the service
//
//  default metadatakey... ?? "eancode";

// This is all business logic - belongs in service
//var orderId = orderCreatedEvent.Order.OrderId;
//if (!storeIds.Contains(orderCreatedEvent.Order.Store.Id.Value))
//{
//    log.LogInformation($"Skipping order #{orderId}");
//    return new ContentResult { Content = $"Skipping order #{orderId}", ContentType = "text/html" };
//}

//Currency currency = Currency.EUR;
//if(!string.IsNullOrEmpty(currencyString) && Enum.TryParse(typeof(Currency), currencyString.ToUpper(), out object currencyObject))
//{
//    currency = (Currency)currencyObject;
//}