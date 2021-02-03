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
    public class P2PTransferRequest : ITransferRequest
    {
        public class P2PTransferRequestBankAccount
        {
            public string AccountNumber { get; set; }
        }

        [JsonConverter(typeof(StringNullableEnumConverter<TransferRequestType>))]
        public TransferRequestType Type => TransferRequestType.P2P;

        /// <summary>
        /// Nome do cliente da conta de destino.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// CPF/CNPJ da conta de destino.
        /// </summary>
        [Required]
        public string Document { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public P2PTransferRequestBankAccount BankAccount { get; set; }
    }
}
