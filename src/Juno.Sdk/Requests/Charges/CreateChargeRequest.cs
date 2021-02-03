using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Charges
{
    public class CreateChargeRequest : AbstractRequest<CreateChargeResource, ChargesResponse>
    {
        public CreateChargeRequest(RequestContext context) : base(context)
        {
        }

        public override ChargesResponse Execute(CreateChargeResource param)
        {
            return Post("charges", param.Charge, param.ResourceToken);
        }
    }
}
