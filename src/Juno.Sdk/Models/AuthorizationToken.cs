using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class AuthorizationToken
    {
        private long _ExpiresIn;
        private DateTime _Expires = DateTime.UtcNow.AddSeconds(-1);

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("jti")]
        public string Jti { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn
        {
            get => _ExpiresIn;
            set
            {
                _ExpiresIn = value;
                _Expires = DateTime.UtcNow.AddSeconds(value);
            }
        }

        [JsonIgnore]
        public DateTime Expires => _Expires;

        [JsonIgnore]
        public bool Expired => DateTime.UtcNow > Expires;
    }
}
