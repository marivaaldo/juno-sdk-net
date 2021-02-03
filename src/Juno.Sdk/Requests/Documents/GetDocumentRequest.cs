using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Documents
{
    public class GetDocumentRequest : AbstractRequest<DocumentResource, Document>
    {
        public GetDocumentRequest(RequestContext context)
            : base(context)
        {
        }

        public override Document Execute(DocumentResource param)
        {
            return Get($"documents/{param.DocumentId}", param.ResourceToken);
        }
    }
}
