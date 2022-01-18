/* 
 * Flipdish Open API v1.0
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
namespace Flipdish.Recruiting.WebhookReceiver.Models
{
    /// <summary>
    /// Voucher summary
    /// </summary>
    [DataContract]
    public partial class OrderVoucherSummary :  IEquatable<OrderVoucherSummary>, IValidatableObject
    {
        /// <summary>
        /// Voucher type
        /// </summary>
        /// <value>Voucher type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum PercentageDiscount for value: PercentageDiscount
            /// </summary>
            [EnumMember(Value = "PercentageDiscount")]
            PercentageDiscount = 1,
            
            /// <summary>
            /// Enum LumpDiscount for value: LumpDiscount
            /// </summary>
            [EnumMember(Value = "LumpDiscount")]
            LumpDiscount = 2,
            
            /// <summary>
            /// Enum AddItem for value: AddItem
            /// </summary>
            [EnumMember(Value = "AddItem")]
            AddItem = 3,
            
            /// <summary>
            /// Enum CreditNote for value: CreditNote
            /// </summary>
            [EnumMember(Value = "CreditNote")]
            CreditNote = 4
        }

        /// <summary>
        /// Voucher type
        /// </summary>
        /// <value>Voucher type</value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Voucher sub type
        /// </summary>
        /// <value>Voucher sub type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubTypeEnum
        {
            
            /// <summary>
            /// Enum None for value: None
            /// </summary>
            [EnumMember(Value = "None")]
            None = 1,
            
            /// <summary>
            /// Enum SignUp for value: SignUp
            /// </summary>
            [EnumMember(Value = "SignUp")]
            SignUp = 2,
            
            /// <summary>
            /// Enum Loyalty for value: Loyalty
            /// </summary>
            [EnumMember(Value = "Loyalty")]
            Loyalty = 3,
            
            /// <summary>
            /// Enum Loyalty25 for value: Loyalty25
            /// </summary>
            [EnumMember(Value = "Loyalty25")]
            Loyalty25 = 4,
            
            /// <summary>
            /// Enum Retention for value: Retention
            /// </summary>
            [EnumMember(Value = "Retention")]
            Retention = 5,
            
            /// <summary>
            /// Enum SecondaryRetention for value: SecondaryRetention
            /// </summary>
            [EnumMember(Value = "SecondaryRetention")]
            SecondaryRetention = 6,
            
            /// <summary>
            /// Enum Custom for value: Custom
            /// </summary>
            [EnumMember(Value = "Custom")]
            Custom = 7
        }

        /// <summary>
        /// Voucher sub type
        /// </summary>
        /// <value>Voucher sub type</value>
        [DataMember(Name="SubType", EmitDefaultValue=false)]
        public SubTypeEnum? SubType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderVoucherSummary" /> class.
        /// </summary>
        /// <param name="name">Voucher name.</param>
        /// <param name="description">Voucher description.</param>
        /// <param name="code">Voucher code.</param>
        /// <param name="amount">Voucher amount.</param>
        /// <param name="type">Voucher type.</param>
        /// <param name="subType">Voucher sub type.</param>
        public OrderVoucherSummary(string name = default(string), string description = default(string), string code = default(string), double? amount = default(double?), TypeEnum? type = default(TypeEnum?), SubTypeEnum? subType = default(SubTypeEnum?))
        {
            this.Name = name;
            this.Description = description;
            this.Code = code;
            this.Amount = amount;
            this.Type = type;
            this.SubType = subType;
        }
        
        /// <summary>
        /// Voucher name
        /// </summary>
        /// <value>Voucher name</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Voucher description
        /// </summary>
        /// <value>Voucher description</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Voucher code
        /// </summary>
        /// <value>Voucher code</value>
        [DataMember(Name="Code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Voucher amount
        /// </summary>
        /// <value>Voucher amount</value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }



        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderVoucherSummary {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  SubType: ").Append(SubType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OrderVoucherSummary);
        }

        /// <summary>
        /// Returns true if OrderVoucherSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderVoucherSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderVoucherSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.SubType == input.SubType ||
                    (this.SubType != null &&
                    this.SubType.Equals(input.SubType))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.SubType != null)
                    hashCode = hashCode * 59 + this.SubType.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
