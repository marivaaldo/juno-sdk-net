using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class ChargesResponse : EmbeddedResponse<ChargesResponse.EmbeddedChargesResponse>
    {
        public class EmbeddedChargesResponse : IEmbeddedResource
        {
            public List<ChargeResource> Charges { get; set; } = new List<ChargeResource>();
        }
    }
}
