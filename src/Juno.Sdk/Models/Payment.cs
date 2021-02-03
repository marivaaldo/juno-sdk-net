using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Payment
    {
        public string Id { get; set; }

        public string ChargeId { get; set; }

        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? Date { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Fee { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<PaymentStatus?>))]
        public PaymentStatus? Status { get; set; }

        public string TransactionId { get; set; }

        public string FailReason { get; set; }
    }
}
