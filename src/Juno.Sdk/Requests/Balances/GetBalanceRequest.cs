using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Balances
{
    public class GetBalanceRequest : AbstractRequest<string, Balance>
    {
        public GetBalanceRequest(RequestContext context)
            : base(context)
        {
        }

        public override Balance Execute(string resourceToken)
        {
            return Get("balance", resourceToken);
        }
    }
}
