using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class EventType
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<EventNameExtended>))]
        public EventNameExtended Name { get; set; }

        public string Label { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<EventStatus>))]
        public EventStatus Status { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
