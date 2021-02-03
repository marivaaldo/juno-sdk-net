using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class DigitalAccountResponse
    {
        public string Id { get; set; }

        public string ResourceToken { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<DigitalAccountStatus>))]
        public DigitalAccountStatus Status { get; set; }

        [JsonConverter(typeof(StringNullableEnumConverter<PersonType>))]
        public PersonType PersonType { get; set; }

        public string Document { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
