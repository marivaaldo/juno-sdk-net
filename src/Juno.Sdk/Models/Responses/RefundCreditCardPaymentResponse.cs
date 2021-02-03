using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class RefundCreditCardPaymentResponse
    {
        public string TransactionId { get; set; }

        public int? Installments { get; set; }

        public List<PaymentRefund> Refunds { get; set; }
    }
}
