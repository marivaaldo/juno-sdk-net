using Juno.Sdk.Converters;
using Juno.Sdk.Extensions;
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
            /// <summary>
            /// Ex: https://domain.com
            /// </summary>
            [JsonIgnore]
            public string BaseUrl { get; set; }

            /// <summary>
            /// Ex:
            ///     MyId = 1
            /// </summary>
            [JsonIgnore]
            public Dictionary<string, object> QueryParameters { get; set; }

            public string Url => GetUrl();

            [JsonConverter(typeof(ListStringNullableEnumConverter<List<EventName>, EventName>))]
            public List<EventName> EventTypes { get; set; }

            private string GetUrl()
            {
                var url = BaseUrl;

                if (!url.EndsWith("/"))
                {
                    url += "/";
                }

                url += "/juno/wh/notifications";

                if (QueryParameters != null && QueryParameters.Count > 0)
                {
                    url = $"?{QueryParameters.ToQueryString()}";
                }

                return url;
            }
        }

        public string ResourceToken { get; set; }

        public CreateWebhook Webhook { get; set; }
    }
}
