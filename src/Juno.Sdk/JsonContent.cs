using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk
{
    public class JsonContent<T> : StringContent
        where T : class, new()
    {
        private static readonly JsonSerializerOptions _JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true,
            //Converters = { new NullableConverterFactory() }
        };

        public JsonContent(T content)
            : base(GetContent(content), Encoding.UTF8, "application/json") { }

        public JsonContent(T content, Encoding encoding)
            : base(GetContent(content), encoding, "application/json") { }

        public JsonContent(T content, Encoding encoding, string mediaType)
            : base(GetContent(content), encoding, mediaType) { }

        private static string GetContent(T content)
        {
            if (content == null)
                return null;

            return JsonSerializer.Serialize(content, _JsonSerializerOptions);
        }
    }
}
