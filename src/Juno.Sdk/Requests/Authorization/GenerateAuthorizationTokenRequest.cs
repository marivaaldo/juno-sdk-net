using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Authorization
{
    public class GenerateAuthorizationTokenRequest : AbstractRequest<AuthorizationToken>
    {
        public GenerateAuthorizationTokenRequest(RequestContext context)
            : base(context)
        {
        }

        public override AuthorizationToken Execute()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, GetUrl("oauth/token", EnvironmentUrl.Authorization));

            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["grant_type"] = "client_credentials"
            }.ToList());

            var response = SendRequest(request, baseUrl: EnvironmentUrl.Authorization);

            return ReadResponse(response);
        }
    }
}
