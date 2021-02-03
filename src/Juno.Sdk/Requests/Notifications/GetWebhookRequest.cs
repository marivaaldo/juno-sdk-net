using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Notifications
{
    public class GetWebhookRequest : AbstractRequest<Models.Requests.WebhookResource, Models.Webhook>
    {
        public GetWebhookRequest(RequestContext context)
            : base(context)
        {
        }

        public override Models.Webhook Execute(Models.Requests.WebhookResource param)
        {
            return Get($"notifications/webhooks/{param.WebhookId}", param.ResourceToken);
        }
    }
}
