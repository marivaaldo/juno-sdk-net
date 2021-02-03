using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Requests.Payments
{
    public class CreditCardTokenizationRequest : AbstractRequest<string, CreditCardToken>
    {
        private class CreditCard
        {
            public string CreditCardHash { get; set; }
        }

        public CreditCardTokenizationRequest(RequestContext context) : base(context)
        {
        }

        public override CreditCardToken Execute(string creditCardHash)
        {
            return Post($"credit-cards/tokenization", new CreditCard { CreditCardHash = creditCardHash });
        }
    }
}
