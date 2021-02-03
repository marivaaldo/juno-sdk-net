using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Converters
{
    public class NullableConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => Nullable.GetUnderlyingType(typeToConvert) != null;

        public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options) =>
            (JsonConverter)Activator.CreateInstance(
                typeof(NullableConverter<>).MakeGenericType(
                    new Type[] { Nullable.GetUnderlyingType(type) }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null);

        class NullableConverter<T> : JsonConverter<T?> where T : struct
        {
            private readonly JsonConverter<T> valueConverter;

            public NullableConverter(JsonSerializerOptions options) => valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));

            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return null;
                if (reader.TokenType == JsonTokenType.String)
                {
                    var s = reader.GetString();
                    if (string.IsNullOrEmpty(s))
                        return null;
                }
                if (valueConverter != null)
                    return valueConverter.Read(ref reader, typeof(T), options);
                else
                    return JsonSerializer.Deserialize<T>(ref reader, options);
            }

            public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
            {
                if (value == null)// Not sure this is needed - the converter is not called for null values by default.
                    writer.WriteNullValue();
                else if (valueConverter != null)
                    valueConverter.Write(writer, value.Value, options);
                else
                    JsonSerializer.Serialize(writer, value.Value, options);
            }
        }
    }
}
