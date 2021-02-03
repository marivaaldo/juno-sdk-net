using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Notifications
{
    public class ListEventTypesRequest : AbstractRequest<EventTypeResponse>
    {
        public ListEventTypesRequest(RequestContext context) : base(context)
        {
        }

        public override EventTypeResponse Execute()
        {
            return Get("notifications/event-types");
        }
    }
}
