using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class DefaultBankAccountTransferRequest : ITransferRequest
    {
        [JsonConverter(typeof(StringNullableEnumConverter<TransferRequestType>))]
        public TransferRequestType Type => TransferRequestType.DEFAULT_BANK_ACCOUNT;

        [Required]
        public decimal Amount { get; set; }
    }
}
