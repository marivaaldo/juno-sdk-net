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
    public class UpdateWebhookRequest : AbstractRequest<UpdateWebhookResource, Models.Webhook>
    {
        public UpdateWebhookRequest(RequestContext context)
            : base(context)
        {
        }

        public override Webhook Execute(UpdateWebhookResource param)
        {
            return Patch($"notifications/webhooks/{param.WebhookId}", param.Webhook, param.ResourceToken);
        }
    }
}
