using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class DefaultNotification : DefaultNotification<object>
    {
        
    }

    public class DefaultNotification<T> : INotification<NotificationData<T>, T>
    {
        public string EventId { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<EventName>))]
        public EventName EventType { get; set; }

        public DateTime Timestamp { get; set; }

        public List<NotificationData<T>> Data { get; set; }
    }

    public class NotificationData<T> : INotificationData<T>
    {
        public string EntityId { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<EntityType>))]
        public EntityType EntityType { get; set; }

        public T Attributes { get; set; }
    }
}

