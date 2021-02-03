using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class TransferResponse
    {
        public string Id { get; set; }

        public string DigitalAccountId { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? TransferDate { get; set; }

        public decimal Amount { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<TransferStatus>))]
        public TransferStatus Status { get; set; }
    }
}
