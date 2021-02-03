using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class DocumentsResponse : EmbeddedResponse<DocumentsResponse.EmbeddedDocumentsResponse>
    {
        public class EmbeddedDocumentsResponse : IEmbeddedResource
        {
            public List<Document> Documents { get; set; }
        }
    }
}
