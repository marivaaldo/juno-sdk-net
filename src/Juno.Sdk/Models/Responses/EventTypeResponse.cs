using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class EventTypeResponse : EmbeddedResponse<EventTypeResponse.EmbeddedEventTypeResponse>
    {
        public class EmbeddedEventTypeResponse : IEmbeddedResource
        {
            public List<EventType> EventTypes { get; set; }
        }
    }
}
