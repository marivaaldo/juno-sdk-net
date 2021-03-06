﻿using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class P2PTransferStatusChanged : DefaultNotification<P2PTransferStatusChanged.P2PTransfer>
    {
        public class P2PTransfer
        {
            public string DigitalAccountId { get; set; }

            public DateTime? CreationDate { get; set; }

            public DateTime? TransferDate { get; set; }

            public decimal? Amount { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<TransferStatus>))]
            public TransferStatus Status { get; set; }

            public P2PTransferRecipient Recipient { get; set; }

            public class P2PTransferRecipient
            {
                public string Name { get; set; }

                public string Document { get; set; }
            }
        }
    }
}
