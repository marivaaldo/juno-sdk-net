using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Webhooks.Queries
{
    public class GetWebhookSecretRequest : IRequest<string>
    {
        public Dictionary<string, List<string>> Parameters { get; set; }
    }
}
