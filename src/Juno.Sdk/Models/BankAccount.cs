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
    public class BankAccount
    {
        /// <summary>
        /// Código de compensação dos bancos do Brasil. Espera 3 digitos.
        /// </summary>
        [Required]
        public string BankNumber { get; set; }

        /// <summary>
        /// Número da agência. Deve respeitar o padrão de cada banco.
        /// </summary>
        [Required]
        public string AgencyNumber { get; set; }

        /// <summary>
        /// Número da conta. Deve respeitar o padrão de cada banco.
        /// </summary>
        [Required]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Complemento da conta a ser criada. Exclusivo e obrigatório apenas para contas Caixa.
        /// Enum: "001" "002" "003" "006" "007" "013" "022" "023" "028" "043" "031"
        /// </summary>
        public string AccountComplementNumber { get; set; }

        /// <summary>
        /// Tipo da conta. Envie CHECKING para Conta Corrente e SAVINGS para Poupança.
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringNullableEnumConverter<BankAccountType>))]
        public BankAccountType AccountType { get; set; }

        /// <summary>
        /// Titular da conta.
        /// </summary>
        [Required]
        public BankAccountHolder AccountHolder { get; set; }
    }
}
