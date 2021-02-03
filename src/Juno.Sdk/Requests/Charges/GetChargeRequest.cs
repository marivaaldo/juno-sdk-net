using Juno.Sdk.Extensions;
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
    public class GetChargeRequest : AbstractRequest<GetChargeResource, ChargeResource>
    {
        public GetChargeRequest(RequestContext context) : base(context)
        {
        }

        public override ChargeResource Execute(GetChargeResource param)
        {
            return Get($"charges/{param.ChargeId}", param.ResourceToken);
        }
    }
}
