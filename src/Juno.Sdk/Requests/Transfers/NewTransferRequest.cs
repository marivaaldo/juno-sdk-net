using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Transfers
{
    public class NewTransferRequest : AbstractRequest<TransferResource, TransferResponse>
    {
        public NewTransferRequest(RequestContext context)
            : base(context)
        {
        }

        public override TransferResponse Execute(TransferResource param)
        {
            return Post("transfers", (object)param.Request);
        }
    }
}
