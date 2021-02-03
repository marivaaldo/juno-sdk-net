using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Notifications
{
    public class DocumentStatusChanged : DefaultNotification<DocumentStatusChanged.Document>
    {
        public class Document
        {
            public string Description { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<DocumentStatus>))]
            public DocumentStatus ApprovalStatus { get; set; }

            [JsonConverter(typeof(StringNullableEnumConverter<DocumentType>))]
            public DocumentType Type { get; set; }
        }
    }
}
