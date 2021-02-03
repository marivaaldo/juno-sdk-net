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
    public class DeleteWebhookRequest : AbstractRequest<Models.Requests.WebhookResource, string>
    {
        public DeleteWebhookRequest(RequestContext context)
            : base(context)
        {
        }

        public override string Execute(Models.Requests.WebhookResource param)
        {
            return Delete($"notifications/webhooks/{param.WebhookId}", param.ResourceToken);
        }
    }
}
