using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum PaymentStatus
    {
        /// <summary>
        /// Pagamento autorizado.
        /// </summary>
        AUTHORIZED,

        /// <summary>
        /// Pagamento rejeitado pela análise de risco.
        /// </summary>
        DECLINED,

        /// <summary>
        /// Pagamento não realizado.
        /// </summary>
        FAILED,

        /// <summary>
        /// Pagamento não autorizado pela instituição responsável pelo cartão de crédito, no caso, a emissora do cartão.
        /// </summary>
        NOT_AUTHORIZED,

        /// <summary>
        /// Pagamento confirmado.
        /// </summary>
        CONFIRMED,

        /// <summary>
        /// Pagamento estornado a pedido do cliente.
        /// </summary>
        CUSTOMER_PAID_BACK,

        /// <summary>
        /// Pagamento estornado a pedido do banco.
        /// </summary>
        BANK_PAID_BACK,

        /// <summary>
        /// Pagamento parcialmente estornado
        /// </summary>
        PARTIALLY_REFUNDED,
    }
}
