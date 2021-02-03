using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class PublicKeysService : AbstractService
    {
        public PublicKeysService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Obtenha a chave pública associada à conta digital para envio de arquivo JWE.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <returns></returns>
        public string GetPublicKey(string resourceToken)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.PublicKeys.GetPublicKeyRequest(Client.GetRequestContext());;

            return request.Execute(resourceToken);
        }
    }
}
