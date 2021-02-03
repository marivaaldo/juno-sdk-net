using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Documents
{
    public class PostEncryptedDocumentRequest : AbstractRequest<PostEncryptedDocument, Document>
    {
        public PostEncryptedDocumentRequest(RequestContext context) : base(context)
        {
        }

        public override Document Execute(PostEncryptedDocument param)
        {
            //var payload = new Dictionary<string, object>()
            //{
            //    ["fn"] = param.File.Name,
            //    ["fc"] = Convert.ToBase64String(param.File.Contents)
            //};

            //var contents = JsonSerializer.Serialize(payload);

            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Audience = "you",
                //Issuer = "me",
                //Subject = new ClaimsIdentity(new List<Claim> { new Claim("sub", "scott") }),
                //EncryptingCredentials = new X509EncryptingCredentials(new X509Certificate2("key_public.cer"))
                //EncryptingCredentials = new credentials
            };

            //tokenDescriptor.AdditionalHeaderClaims

            //string token = handler.CreateEncodedJwt(tokenDescriptor);

            throw new NotImplementedException(); //FIXME PostEncryptedDocumentRequest
        }
    }
}
