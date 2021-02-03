using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class CancelChargeResource : IRequestResource
    {
        public string ResourceToken { get; set; }

        public string ChargeId { get; set; }
    }
}
