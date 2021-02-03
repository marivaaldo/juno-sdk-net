using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class BillingForPayment
    {
        [StringLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Endereço.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Pagamento realizados com cartão de crédito podem utilizar a funcionalidade de captura tardia. 
        /// A captura tardia consiste apenas na autorização de um pagamento sem a sua efetivação, o valor autorizado fica retido no limite do cartão de crédito do pagador até a captura ou cancelamento.
        /// </summary>
        public bool? Delayed { get; set; }
    }
}
