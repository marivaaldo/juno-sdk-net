using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class ChargeStatusChanged : DefaultNotification<ChargeStatusChanged.Charge>
    {
        public class Charge
        {
            public string DigitalAccountId { get; set; }

            public long Code { get; set; }

            public string Reference { get; set; }

            public decimal? Amount { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<ChargeStatus>))]
            public ChargeStatus Status { get; set; }

            [DateTimeNullableFormatConverter("yyyy-MM-dd")]
            public DateTime? DueDate { get; set; }
        }
    }
}
