using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk
{
    public class Credentials
    {
        public int ApiVersion { get; set; } = 2;

        /// <summary>
        /// Id da Credencial de acesso à API de integração.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Secret da Credencial de acesso à API de integração.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Código de identificação do seu cadastro dentro do sistema que você integrará com a Juno. É ele que permite e identifica seu acesso, via API
        /// </summary>
        public string PrivateToken { get; set; }

        /// <summary>
        /// Código usado no processo de criptografia de cartões de crédito. Em outras palavras, é ele quem transforma os dados do cartão do seu cliente em uma informação segura.
        /// </summary>
        public string PublicToken { get; set; }

        /// <summary>
        /// Usado quando você indica amigos ou parceiros para utilizar a Juno de forma integrada, no seu sistema, com um cadastro que ficará vinculado ao seu.
        /// O token de indicação deve ser utilizado em todas as chamadas de emissão de cobranças feitas pelo seu sistema.
        /// </summary>
        public string ReferralToken { get; set; }

        public string Hash
        {
            get
            {
                byte[] bytes = Encoding.ASCII.GetBytes($"{ClientId}:{ClientSecret}");

                string base64 = System.Convert.ToBase64String(bytes);

                return base64;
            }
        }
    }
}
