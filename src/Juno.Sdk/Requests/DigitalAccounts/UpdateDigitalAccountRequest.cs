using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.DigitalAccounts
{
    public class UpdateDigitalAccountRequest : AbstractRequest<DigitalAccount, DigitalAccountResponse>
    {
        public UpdateDigitalAccountRequest(RequestContext context)
            : base(context)
        {
        }

        public override DigitalAccountResponse Execute(DigitalAccount param)
        {
            return Patch("digital-accounts", param);
        }
    }
}
