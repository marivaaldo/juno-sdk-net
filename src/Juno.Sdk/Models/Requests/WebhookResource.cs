using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class WebhookResource : IRequestResource
    {
        public string ResourceToken { get; set; }

        public string WebhookId { get; set; }
    }
}
