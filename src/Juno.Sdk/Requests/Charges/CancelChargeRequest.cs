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
    public class CancelChargeRequest : AbstractRequest<CancelChargeResource, string>
    {
        public CancelChargeRequest(RequestContext context) : base(context)
        {
        }

        public override string Execute(CancelChargeResource param)
        {
            return Put($"charges/{param.ChargeId}/cancelation", param.ResourceToken);
        }
    }
}
