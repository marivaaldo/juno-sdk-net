using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class RefundCreditCardPaymentResource : IRequestResource
    {
        public class RefundCreditCardPayment
        {

            /// <summary>
            /// Para estorno parcial, a quantidade definida em amount deve ser menor que o valor total da transação. Caso não seja passado nenhum valor nesse parâmetro, será feito o estorno total da transação.
            /// </summary>
            public decimal? Amount { get; set; }

            public List<Split> Split { get; set; }
        }

        public string ResourceToken { get; set; }

        public string PaymentId { get; set; }

        public RefundCreditCardPayment Refund { get; set; }
    }
}
