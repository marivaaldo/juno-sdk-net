using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class BilletDetails
    {
        /// <summary>
        /// Conta bancária.
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// Nosso número.
        /// </summary>
        public string OurNumber { get; set; }

        /// <summary>
        /// Código de barras.
        /// </summary>
        public string BarcodeNumber { get; set; }

        /// <summary>
        /// Carteira bancária.
        /// </summary>
        public string Portfolio { get; set; }
    }
}
