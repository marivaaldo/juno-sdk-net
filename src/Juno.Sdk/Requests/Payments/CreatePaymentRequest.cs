using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Payments
{
    public class CreatePaymentRequest : AbstractRequest<CreatePaymentResource, PaymentResponse>
    {
        public CreatePaymentRequest(RequestContext context) : base(context)
        {
        }

        public override PaymentResponse Execute(CreatePaymentResource param)
        {
            return Post("payments", param.Payment, param.ResourceToken);
        }
    }
}
