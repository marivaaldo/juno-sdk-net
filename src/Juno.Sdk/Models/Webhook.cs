using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Webhook
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string Secret { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<WebhookStatus>))]
        public WebhookStatus Status { get; set; }

        public List<EventType> EventTypes { get; set; }
    }

    public enum WebhookStatus
    {
        ACTIVE,

        INACTIVE
    }
}
