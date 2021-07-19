using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum EventName
    {
        /// <summary>
        /// Mudanças de status de uma conta digital
        /// </summary>
        DIGITAL_ACCOUNT_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de um documento da conta digital
        /// </summary>
        DOCUMENT_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma transferência
        /// </summary>
        TRANSFER_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma transferência P2P
        /// </summary>
        P2P_TRANSFER_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma cobrança emitida
        /// </summary>
        CHARGE_STATUS_CHANGED,

        /// <summary>
        /// Confirmação de leitura/visualização de uma cobrança
        /// </summary>
        CHARGE_READ_CONFIRMATION,

        /// <summary>
        /// Pagamento de uma cobranças
        /// </summary>
        PAYMENT_NOTIFICATION,

        /// <summary>
        /// Mudança de status de um pagamento
        /// </summary>
        BILL_PAYMENT_STATUS_CHANGED,

        /// <summary>
        /// Confirmação de criação de uma conta digital - Válido somente para a solução Whitelabel
        /// </summary>
        DIGITAL_ACCOUNT_CREATED,

        //CHARGE_CREATED,

        //PAYMENT_RECEIVED
    }

    public enum EventNameExtended
    {
        /// <summary>
        /// Mudanças de status de uma conta digital
        /// </summary>
        DIGITAL_ACCOUNT_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de um documento da conta digital
        /// </summary>
        DOCUMENT_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma transferência
        /// </summary>
        TRANSFER_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma transferência P2P
        /// </summary>
        P2P_TRANSFER_STATUS_CHANGED,

        /// <summary>
        /// Mudanças de status de uma cobrança emitida
        /// </summary>
        CHARGE_STATUS_CHANGED,

        /// <summary>
        /// Confirmação de leitura/visualização de uma cobrança
        /// </summary>
        CHARGE_READ_CONFIRMATION,

        /// <summary>
        /// Pagamento de uma cobranças
        /// </summary>
        PAYMENT_NOTIFICATION,

        /// <summary>
        /// Mudança de status de um pagamento
        /// </summary>
        BILL_PAYMENT_STATUS_CHANGED,

        CHARGE_CREATED,

        PAYMENT_RECEIVED,

        DIGITAL_ACCOUNT_CREATED
    }
}
