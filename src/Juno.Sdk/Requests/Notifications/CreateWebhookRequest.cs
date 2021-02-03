using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Notifications
{
    public class CreateWebhookRequest : AbstractRequest<CreateWebhookResource, Models.Webhook>
    {
        public CreateWebhookRequest(RequestContext context)
            : base(context)
        {
        }

        public override Webhook Execute(CreateWebhookResource param)
        {
            return Post("notifications/webhooks", param.Webhook, param.ResourceToken);
        }
    }
}
