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
    public class ListBusinessAreasRequest : AbstractRequest<BusinessAreasResponse>
    {
        public ListBusinessAreasRequest(RequestContext context)
            : base(context)
        {
        }

        public override BusinessAreasResponse Execute()
        {
            return Get("data/business-areas");
        }
    }
}
