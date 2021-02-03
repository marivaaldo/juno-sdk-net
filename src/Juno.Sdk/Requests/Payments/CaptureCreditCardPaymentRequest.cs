using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Payments
{
    public class CaptureCreditCardPaymentRequest : AbstractRequest<CaptureCreditCardPaymentResource, PaymentResponse>
    {
        public CaptureCreditCardPaymentRequest(RequestContext context) : base(context)
        {
        }

        public override PaymentResponse Execute(CaptureCreditCardPaymentResource param)
        {
            return Post($"payments/{param.PaymentId}/capture", param.Payment, param.ResourceToken);
        }
    }
}
