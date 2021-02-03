using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class BankAccountHolder
    {
        /// <summary>
        /// Nome do titular da conta bancária.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// CPF ou CNPJ do titular da conta bancária. Envie em ponto ou traço.
        /// </summary>
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string Document { get; set; }
    }
}
