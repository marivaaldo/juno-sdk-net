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
    public class ListWebhooksRequest : AbstractRequest<string, WebhooksResponse>
    {
        public ListWebhooksRequest(RequestContext context)
            : base(context)
        {
        }

        public override WebhooksResponse Execute(string resourceToken)
        {
            return Get("notifications/webhooks", resourceToken);
        }
    }
}
