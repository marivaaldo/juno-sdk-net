using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class DigitalAccountStatusChanged : DefaultNotification<DigitalAccountStatusChanged.DigitalAccount>
    {
        public class DigitalAccount
        {
            [JsonConverter(typeof(StringNullableEnumConverter<DigitalAccountStatus>))]
            public DigitalAccountStatus PreviousStatus { get; set; }


            [JsonConverter(typeof(StringNullableEnumConverter<DigitalAccountStatus>))]
            public DigitalAccountStatus Status { get; set; }
        }
    }
}
