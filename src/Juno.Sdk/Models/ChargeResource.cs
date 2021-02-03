using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class ChargeResource
    {
        public string Id { get; set; }

        public long Code { get; set; }

        public string Reference { get; set; }

        public DateTime? DueDate { get; set; }

        public string Link { get; set; }

        public string CheckoutUrl { get; set; }

        public string InstallmentLink { get; set; }

        public string PayNumber { get; set; }

        public decimal Amount { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<ChargeStatus>))]
        public ChargeStatus Status { get; set; }

        public BilletDetails BilletDetails { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Pix> Pix { get; set; }
    }
}
