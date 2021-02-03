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
    public class CreateDigitalAccountRequest : AbstractRequest<DigitalAccount, DigitalAccountResponse>
    {
        public CreateDigitalAccountRequest(RequestContext context)
            : base(context)
        {
        }

        public override DigitalAccountResponse Execute(DigitalAccount param)
        {
            return Post("digital-accounts", param);
        }
    }
}
