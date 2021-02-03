using Juno.Sdk.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Converters
{
    public class ListStringNullableEnumConverter<T, K> : JsonConverter<T>
        where T : IEnumerable<K>, new()
        where K : struct
    {
        public ListStringNullableEnumConverter() { }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableTo(typeof(IEnumerable<K>));
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string text = reader.GetString().Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                return default;
            }

            text = text[1..^1];

            List<K> result = new List<K>();

            foreach (var valueText in text.Split(","))
            {
                if (!Enum.TryParse(valueText, ignoreCase: false, out K value) &&
                    !Enum.TryParse(valueText, ignoreCase: true, out value))
                {
                    throw new JsonException(
                        $"Unable to convert \"{value}\" to Enum \"{typeToConvert}\".");
                }

                result.Add(value);
            }

            return (T)result.AsEnumerable();
        }

        public override void Write(Utf8JsonWriter writer,
            T value, JsonSerializerOptions options)
        {
            var values = value.Select(o => o).ToList();

            writer.WriteStartArray();
            
            for (int i = 0; i < values.Count; i++)
            {
                if (i > 0)
                {
                }
                writer.WriteStringValue(values[i].ToString());
            }
            
            writer.WriteEndArray();
        }
    }
}
