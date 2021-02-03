using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public interface INotification : MediatR.INotification
    {
        string EventId { get; set; }

        EventName EventType { get; set; }

        DateTime Timestamp { get; set; }
    }

    public interface INotification<T, K> : INotification
        where T : INotificationData<K>
    {
        List<T> Data { get; set; }
    }

    public interface INotificationData
    {
        string EntityId { get; set; }

        EntityType EntityType { get; set; }
    }

    public interface INotificationData<K> : INotificationData
    {
        K Attributes { get; set; }
    }
}
