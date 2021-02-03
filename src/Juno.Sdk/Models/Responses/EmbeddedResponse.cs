using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class EmbeddedResponse<Resource>
        where Resource : IEmbeddedResource, new()
    {
        [JsonPropertyName("_embedded")]
        public Resource Embedded { get; set; } = new Resource();
    }

    public interface IEmbeddedResource
    {

    }
}
