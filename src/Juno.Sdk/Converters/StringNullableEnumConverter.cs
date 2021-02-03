using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Converters
{
    public class StringNullableEnumConverter<T> : JsonConverter<T>
    {
        public StringNullableEnumConverter()
        {
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum || typeToConvert.GenericTypeArguments[0].IsEnum;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();

            if (!typeToConvert.IsEnum)
            {
                typeToConvert = typeToConvert.GenericTypeArguments[0];
            }

            if (String.IsNullOrEmpty(value)) return default;

            if (!Enum.TryParse(typeToConvert, value, ignoreCase: false, out object result) &&
                !Enum.TryParse(typeToConvert, value, ignoreCase: true, out result))
            {
                throw new JsonException(
                    $"Unable to convert \"{value}\" to Enum \"{typeToConvert}\".");
            }

            return (T)result;
        }

        public override void Write(Utf8JsonWriter writer,
            T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString());
        }
    }
}
