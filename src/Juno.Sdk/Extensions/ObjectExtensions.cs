using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Juno.Sdk.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerOptions _JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        public static string ToQueryString<T>(this T obj)
            where T : class
        {
            if (obj == null)
                return null;

            var json = JsonSerializer.Serialize(obj, _JsonSerializerOptions);
            var values = JsonSerializer.Deserialize<Dictionary<string, object>>(json, _JsonSerializerOptions);
            var queryString = values.ToQueryString();

            return queryString;
        }

        public static string ToQueryString(this Dictionary<string, object> values)
        {
            if (values == null)
                return null;

            var queryString = string.Join("&", values.Select(o => $"{HttpUtility.UrlEncode(o.Key)}={HttpUtility.UrlEncode(o.Value?.ToString())}"));

            return queryString;
        }
    }
}
