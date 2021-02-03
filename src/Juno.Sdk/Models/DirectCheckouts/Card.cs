using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.DirectCheckouts
{
    public class Card
    {
        private string _CardNumber;

        public string CardNumber
        {
            get => _CardNumber;
            set => _CardNumber = value?.Replace(" ", "");
        }

        public string HolderName { get; set; }

        public string SecurityCode { get; set; }

        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }
    }
}
