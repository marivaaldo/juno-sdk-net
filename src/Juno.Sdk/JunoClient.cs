using Juno.Sdk.Models;
using Juno.Sdk.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk
{
    /// <summary>
    /// TODO Juno - Implementar serviços de Assinaturas
    /// TODO Juno - Implementar serviços de Pagamento de Contas
    /// TODO Juno - Implementar serviços do PicPay
    /// TODO Juno - Implementar serviços do Pix
    /// </summary>
    public class JunoClient
    {
        #region Fields

        public IEnvironment Environment { get; }
        public HttpClient HttpClient { get; set; }
        public Credentials Credentials { get; }
        public AuthorizationToken AuthorizationToken { get; set; }

        #endregion

        public bool Authenticated => AuthorizationToken != null && !AuthorizationToken.Expired;

        public JunoClient(Credentials credentials, IEnvironment environment)
        {
            Credentials = credentials;
            Environment = environment;

            Initialize();
        }

        /// <summary>
        /// Autentica o cliente da API.
        /// </summary>
        /// <returns></returns>
        public bool Authenticate()
        {
            var request = new Requests.Authorization.GenerateAuthorizationTokenRequest(GetRequestContext());

            AuthorizationToken = request.Execute();

            return AuthorizationToken != null && !AuthorizationToken.Expired;
        }

        // TODO GetRequestContext melhorar performance - criar objeto só quando precisar
        public RequestContext GetRequestContext()
        {
            return new RequestContext()
            {
                Environment = Environment,
                HttpClient = HttpClient,
                Credentials = Credentials,
                AuthorizationToken = AuthorizationToken
            };
        }

        #region Private Methods

        private void Initialize()
        {
            CreateHttpClient();
        }

        private void CreateHttpClient()
        {
            HttpClient = new HttpClient();

            HttpClient.DefaultRequestHeaders.Add("X-Api-Version", Credentials.ApiVersion.ToString());
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json;charset=UTF-8");
            HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=UTF-8");
        }

        #endregion
    }
}
