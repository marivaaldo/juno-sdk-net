using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class CreditCardDetails
    {
        /// <summary>
        /// Id do cartão de crédito gerado a partir da Tokenização. Caso seja utilizado esse parâmetro, não deve ser enviado o <see cref="CreditCardHash"/>.
        /// </summary>
        public string CreditCardId { get; set; }

        /// <summary>
        /// Hash do cartão de crédito gerado a partir da comunicação da Biblioteca de Criptografia. Caso seja utilizado esse parâmetro, não deve ser enviado o <see cref="CreditCardId"/>.
        /// </summary>
        public string CreditCardHash { get; set; }
    }
}
