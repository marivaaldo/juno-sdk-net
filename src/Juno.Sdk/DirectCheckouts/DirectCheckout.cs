using Juno.Sdk.DirectCheckouts;
using Juno.Sdk.Models.DirectCheckouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.DirectCheckouts
{
    public class DirectCheckout
    {
        private const string ProductionUrl = "https://www.boletobancario.com/boletofacil/integration/api/";
        private const string SandboxUrl = "https://sandbox.boletobancario.com/boletofacil/integration/api/";

        private readonly string _PublicToken;

        private readonly HttpClient _HttpClient;

        private string _PublicKey;

        public DirectCheckout(string publicToken, bool production = true)
        {
            _PublicToken = publicToken;

            _HttpClient = new HttpClient
            {
                BaseAddress = new Uri(production ? ProductionUrl : SandboxUrl)
            };

            _HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            GetPublicKey();
        }

        public string GetCardHash(Card card)
        {
            var encryptedCard = card.Encrypt(_PublicKey);

            var response = _HttpClient.PostAsync("get-credit-card-hash.json", new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["publicToken"] = _PublicToken,
                ["encryptedData"] = encryptedCard
            }.ToList()))
                .GetAwaiter()
                .GetResult();

            var contents = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var result = JsonSerializer.Deserialize<Result>(contents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (result == null || !result.Success)
            {
                throw new InvalidOperationException("Error while create credit card hash", new Exception(result?.ErrorMessage));
            }

            return result.Data;
        }

        #region Private Methods

        private void GetPublicKey()
        {
            var response = _HttpClient.PostAsync("get-public-encryption-key.json", new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["publicToken"] = _PublicToken,
                ["version"] = "0.0.2"
            }.ToList()))
                .GetAwaiter()
                .GetResult();

            var contents = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var result = JsonSerializer.Deserialize<Result>(contents, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (result == null || !result.Success)
            {
                throw new InvalidOperationException("Error while get public key", new Exception(result?.ErrorMessage));
            }

            _PublicKey = result.Data;
        }

        #endregion
    }
}
