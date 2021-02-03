using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class WebhooksResponse : EmbeddedResponse<WebhooksResponse.EmbeddedWebhooksResponse>
    {
        public class EmbeddedWebhooksResponse : IEmbeddedResource
        {
            public List<Webhook> Webhooks { get; set; }
        }
    }
}
