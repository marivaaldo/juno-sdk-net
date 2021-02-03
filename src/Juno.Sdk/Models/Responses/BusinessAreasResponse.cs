using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class BusinessAreasResponse : EmbeddedResponse<BusinessAreasResponse.EmbeddedBusinessAreasResponse>
    {
        public class EmbeddedBusinessAreasResponse : IEmbeddedResource
        {
            public List<BusinessArea> BusinessAreas { get; set; }
        }
    }
}
