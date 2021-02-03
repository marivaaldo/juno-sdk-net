using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class CaptureCreditCardPaymentResource : IRequestResource
    {
        public class CaptureCreditCardPayment
        {
            [Required]
            public string ChargeId { get; set; }

            /// <summary>
            /// Para captura parcial, a quantidade definida deve ser menor que o valor total da transação. Caso não seja passado nenhum valor nesse parâmetro, será feita a captura total da transação.
            /// </summary>
            public decimal? Amount { get; set; }
        }

        public string ResourceToken { get; set; }

        public string PaymentId { get; set; }

        public CaptureCreditCardPayment Payment { get; set; }
    }
}
