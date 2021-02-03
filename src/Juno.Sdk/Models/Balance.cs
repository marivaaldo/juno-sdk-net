using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Balance
    {
        /// <summary>
        /// Soma do saldo a liberar e saldo disponível.
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal Total { get; set; }

        /// <summary>
        /// Saldo a liberar. Valor referente aos recebimentos do cartão de crédito que fica "em espera" durante o prazo de retenção acordado para esse meio de pagamento. Finalizado o prazo de retenção, esse valor é transferido automaticamente para o saldo disponível.
        /// </summary>
        public decimal WithheldBalance { get; set; }

        /// <summary>
        /// Saldo disponível. Valor referente aos recebimentos, independentemente do tipo de pagamento, que já podem ser utilizados na transferência ou pagamento de contas.
        /// </summary>
        public decimal TransferableBalance { get; set; }
    }
}
