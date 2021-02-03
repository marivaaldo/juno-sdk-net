using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class CreatePaymentResource : IRequestResource
    {
        public class CreatePayment
        {
            public string ChargeId { get; set; }

            public BillingForPayment Billing { get; set; }

            public CreditCardDetails CreditCardDetails { get; set; }
        }

        public string ResourceToken { get; set; }

        public CreatePayment Payment { get; set; }
    }
}
