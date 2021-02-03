using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
            where T : class
        {
            if (httpContent == null)
                return null;

            var contents = await httpContent.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(contents))
                return null;

            return JsonSerializer.Deserialize<T>(contents);
        }
    }
}
