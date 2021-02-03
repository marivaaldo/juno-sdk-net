using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class LegalRepresentative
    {
        public string Name { get; set; }

        public string Document { get; set; }

        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? BirthDate { get; set; }
    }
}
