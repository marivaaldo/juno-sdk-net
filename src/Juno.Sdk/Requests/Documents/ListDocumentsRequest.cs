using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Documents
{
    public class ListDocumentsRequest : AbstractRequest<string, DocumentsResponse>
    {
        public ListDocumentsRequest(RequestContext context)
            : base(context)
        {
        }

        public override DocumentsResponse Execute(string resourceToken)
        {
            return Get("documents", resourceToken);
        }
    }
}
