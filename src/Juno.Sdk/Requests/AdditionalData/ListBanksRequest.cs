using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.AdditionalData
{
    public class ListBanksRequest : AbstractRequest<BanksResponse>
    {
        public ListBanksRequest(RequestContext context)
            : base(context)
        {
        }

        public override BanksResponse Execute()
        {
            return Get("data/banks");
        }
    }
}
