using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.PublicKeys
{
    public class GetPublicKeyRequest : AbstractRequest<string, string>
    {
        public GetPublicKeyRequest(RequestContext context)
            : base(context)
        {
        }

        public override string Execute(string resourceToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, GetUrl("credentials/public-key", EnvironmentUrl.Resources));

            request.Headers.TryAddWithoutValidation("Accept", "text/plain");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _Context.AuthorizationToken.AccessToken);
            request.Headers.TryAddWithoutValidation("X-Resource-Token", resourceToken);

            var response = _Context.HttpClient.Send(request);

            var publicKey = ReadPlainResponse(response);

            return publicKey;
        }
    }
}
