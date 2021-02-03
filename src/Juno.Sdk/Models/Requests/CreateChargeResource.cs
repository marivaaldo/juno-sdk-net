using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class CreateChargeResource : IRequestResource
    {
        public class CreateCharge
        {
            public Charge Charge { get; set; }

            public BillingForCharge Billing { get; set; }
        }

        public string ResourceToken { get; set; }

        public CreateCharge Charge { get; set; }
    }
}
