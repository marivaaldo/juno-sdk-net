using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class UpdateWebhookResource : IRequestResource
    {
        public class UpdateWebhook
        {
            [JsonConverter(typeof(StringNullableEnumConverter<WebhookStatus>))]
            public WebhookStatus Status { get; set; }

            [JsonConverter(typeof(ListStringNullableEnumConverter<List<EventName>, EventName>))]
            public List<EventName> EventTypes { get; set; }
        }

        public string ResourceToken { get; set; }

        public string WebhookId { get; set; }

        public UpdateWebhook Webhook { get; set; }
    }
}
