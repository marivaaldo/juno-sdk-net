using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class PaymentRefund
    {
        public string Id { get; set; }

        public string ChargeId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? PaybackDate { get; set; }

        public decimal PaybackAmount { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<PaymentRefundStatus>))]
        public PaymentRefundStatus Status { get; set; }
    }
}
