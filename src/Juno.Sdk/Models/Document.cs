using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Document
    {
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tipo do documento.
        /// </summary>
        [JsonConverter(typeof(StringNullableEnumConverter<DocumentType>))]
        public DocumentType Type { get; set; }

        /// <summary>
        /// Descrição.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Status de aprovação.
        /// </summary>
        [JsonConverter(typeof(StringNullableEnumConverter<DocumentStatus>))]
        public DocumentStatus ApprovalStatus { get; set; }

        /// <summary>
        /// Motivo caso o documento tenha sido rejeitado.
        /// </summary>
        public string RejectionReason { get; set; }

        /// <summary>
        /// Detalhes.
        /// </summary>
        public string Details { get; set; }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
