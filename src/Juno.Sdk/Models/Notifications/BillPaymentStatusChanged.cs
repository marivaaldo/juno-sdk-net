using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class BillPaymentStatusChanged : DefaultNotification<BillPaymentStatusChanged.BillPayment>
    {
        public class BillPayment
        {
            public string NumericalBarCode { get; set; }

            public decimal? BillAmount { get; set; }

            [DateTimeNullableFormatConverter("yyyy-MM-dd")]
            public DateTime? DueDate { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<PaymentType>))]
            public PaymentType BillType { get; set; }

            public string DigitalAccountId { get; set; }

            public decimal? PaidAmount { get; set; }

            [DateTimeNullableFormatConverter("yyyy-MM-dd")]
            public DateTime? PaymentDate { get; set; }

            public string PaymentDescription { get; set; }

            public string BeneficiaryDocument { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<BillPaymentStatus>))]
            public BillPaymentStatus Status { get; set; }

            [DateTimeNullableFormatConverter("yyyy-MM-dd")]
            public DateTime? CreatedOn { get; set; }
        }
    }
}
