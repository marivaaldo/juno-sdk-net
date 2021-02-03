using Juno.Sdk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Charges
{
    public class UpdateChargeSplitRequest : AbstractRequest<UpdateChargeSplitResource, string>
    {
        public UpdateChargeSplitRequest(RequestContext context) : base(context)
        {
        }

        public override string Execute(UpdateChargeSplitResource param)
        {
            return Put($"charges/{param.ChargeId}/split", param.Split, param.ResourceToken);
        }
    }
}
