using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public enum EntityType
    {
        /// <summary>
        /// Conta digital.
        /// </summary>
        DIGITAL_ACCOUNT,

        /// <summary>
        /// Documento.
        /// </summary>
        DOCUMENT,

        /// <summary>
        /// Cobrança
        /// </summary>
        CHARGE,

        /// <summary>
        /// Pagamento.
        /// </summary>
        PAYMENT,

        /// <summary>
        /// Transferência
        /// </summary>
        TRANSFER,

        /// <summary>
        /// Transferência P2P
        /// </summary>
        P2P_TRANSFER,

        /// <summary>
        /// Pagamento de contas
        /// </summary>
        BILL_PAYMENT
    }
}
