using Juno.Sdk.Extensions;
using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Charges
{
    public class ListChargesRequest : AbstractRequest<ListChargeResource, ChargesResponse>
    {
        public ListChargesRequest(RequestContext context) : base(context)
        {
        }

        public override ChargesResponse Execute(ListChargeResource param)
        {
            var queryString = param.ToQueryString();

            if (!string.IsNullOrWhiteSpace(queryString))
            {
                queryString = $"?{queryString}";
            }

            return Get($"charges{queryString}", param.ResourceToken);
        }
    }
}
