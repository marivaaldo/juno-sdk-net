using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class TransferResource : IRequestResource
    {
        public string ResourceToken { get; set; }

        public ITransferRequest Request { get; set; }
    }
}
