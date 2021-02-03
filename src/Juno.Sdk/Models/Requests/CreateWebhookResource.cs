using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class CreateWebhookResource : IRequestResource
    {
        public class CreateWebhook
        {
            public string Url { get; set; }

            [JsonConverter(typeof(ListStringNullableEnumConverter<List<EventName>, EventName>))]
            public List<EventName> EventTypes { get; set; }
        }

        public string ResourceToken { get; set; }

        public CreateWebhook Webhook { get; set; }
    }
}
