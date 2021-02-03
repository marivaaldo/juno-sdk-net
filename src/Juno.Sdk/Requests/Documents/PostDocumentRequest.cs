using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Documents
{
    public class PostDocumentRequest : AbstractRequest<PostDocumentResource, Document>
    {
        public PostDocumentRequest(RequestContext context)
            : base(context)
        {
        }

        public override Document Execute(PostDocumentResource param)
        {
            var url = GetUrl($"documents/{param.DocumentId}/files", EnvironmentUrl.Resources);

            using var content = new MultipartFormDataContent();

            foreach (var file in param.Files)
            {
                var fileContent = new ByteArrayContent(file.Contents);
                content.Add(fileContent, "files", file.Name);
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");

            var response = SendRequest(request, param.ResourceToken);

            return ReadResponse(response);
        }
    }
}
