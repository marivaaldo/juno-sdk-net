using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Payments
{
    public class RefundCreditCardPaymentRequest : AbstractRequest<RefundCreditCardPaymentResource, RefundCreditCardPaymentResponse>
    {
        public RefundCreditCardPaymentRequest(RequestContext context) : base(context)
        {
        }

        public override RefundCreditCardPaymentResponse Execute(RefundCreditCardPaymentResource param)
        {
            return Post($"payments/{param.PaymentId}/refunds", param.Refund, param.ResourceToken);
        }
    }
}
