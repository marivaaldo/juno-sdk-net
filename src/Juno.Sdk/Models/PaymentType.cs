using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum PaymentType
    {
        /// <summary>
        /// Boleto Bancário.
        /// </summary>
        BOLETO,

        /// <summary>
        /// Boleto com QR Code PIX.
        /// </summary>
        BOLETO_PIX,

        /// <summary>
        /// Cartão de Crédito.
        /// 
        /// Obrigatório no checkout transparente.
        /// </summary>
        CREDIT_CARD,

        INSTALLMENT_CREDIT_CARD
    }
}
