using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class BillingForCharge
    {
        /// <summary>
        /// Nome do comprador.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// CPF ou CNPJ do comprador. Envie sem ponto ou traço.
        /// </summary>
        [Required]
        public string Document { get; set; }

        /// <summary>
        /// Email do comprador.
        /// </summary>
        [StringLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Email secundário do comprador.
        /// </summary>
        [StringLength(80)]
        public string SecondaryEmail { get; set; }

        /// <summary>
        /// Telefone do comprador.
        /// </summary>
        [StringLength(25)]
        public string Phone { get; set; }

        /// <summary>
        /// Data de nascimento do comprador.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Define se o compador receberá emails de notificação diretamente da Juno
        /// </summary>
        public bool? Notify { get; set; }
    }
}
