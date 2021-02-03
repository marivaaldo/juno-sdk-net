using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class PaymentResponse
    {
        public string TransactionId { get; set; }

        public int? Installments { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
