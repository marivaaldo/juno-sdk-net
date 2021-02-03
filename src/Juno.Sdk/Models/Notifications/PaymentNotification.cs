using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class PaymentNotification : DefaultNotification<PaymentNotification.Payment>
    {
        public class Payment
        {
            public string DigitalAccountId { get; set; }

            public DateTime? CreatedOn { get; set; }

            public DateTime? Date { get; set; }

            public DateTime? ReleaseDate { get; set; }

            public decimal? Amount { get; set; }

            public decimal? Fee { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<PaymentStatus>))]
            public PaymentStatus Status { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<PaymentType>))]
            public PaymentType Type { get; set; }

            public DateTime? PaybackDate { get; set; }

            public decimal? PaybackAmount { get; set; }

            public PaymentCharge Charge { get; set; }

            public class PaymentCharge
            {
                public string Id { get; set; }

                public long Code { get; set; }

                public DateTime? DueDate { get; set; }

                public decimal? Amount { get; set; }
            }
        }
    }
}
