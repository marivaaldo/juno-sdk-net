using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class BanksResponse : EmbeddedResponse<BanksResponse.EmbeddedBanksResource>
    {
        public class EmbeddedBanksResource : IEmbeddedResource
        {
            public List<Bank> Banks { get; set; }
        }
    }
}
