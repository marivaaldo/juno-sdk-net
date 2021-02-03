using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class CreditCardToken
    {
        public string CreditCardId { get; set; }

        public string Last4CardNumber { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }
    }
}
