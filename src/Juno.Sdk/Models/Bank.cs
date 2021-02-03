using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Bank
    {
        /// <summary>
        /// Código do Banco.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Nome do Banco.
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Name}";
        }
    }
}
