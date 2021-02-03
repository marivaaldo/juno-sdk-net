using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Converters
{
    public class DateTimeNullableFormatConverter : JsonConverter<DateTime?>
    {
        public string Format { get; set; }

        public DateTimeNullableFormatConverter(string format)
        {
            Format = format;
        }

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                return null;

            return DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime? dateTimeValue,
            JsonSerializerOptions options)
        {
            string value = dateTimeValue.HasValue ? dateTimeValue.Value.ToString(Format, CultureInfo.InvariantCulture) : null;

            writer.WriteStringValue(value);
        }
    }

    public class DateTimeNullableFormatConverterAttribute : JsonConverterAttribute
    {
        public string Format { get; set; }

        public DateTimeNullableFormatConverterAttribute(string format)
        {
            Format = format;
        }

        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            return new DateTimeNullableFormatConverter(Format);
        }
    }
}
