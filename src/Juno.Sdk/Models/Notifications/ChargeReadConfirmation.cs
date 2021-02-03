using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class ChargeReadConfirmation : DefaultNotification<ChargeReadConfirmation.Charge>
    {
        public class Charge
        {
            public string DigitalAccountId { get; set; }

            public long Code { get; set; }

            public string Reference { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<ChargeReadingSource>))]
            public ChargeReadingSource Source { get; set; }
        }
    }
}
