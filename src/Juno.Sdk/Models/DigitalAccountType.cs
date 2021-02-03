using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum DigitalAccountType
    {
        /// <summary>
        /// Padrão.
        /// 
        /// Funcionalidades completas de uma conta digital.
        /// Todas as funcionalidades disponíveis.
        /// </summary>
        PAYMENT,

        /// <summary>
        /// Conta digital apenas para recebimentos.
        /// 
        /// Apenas funcionalidades para recebimentos disponíveis.
        /// </summary>
        RECEIVING
    }
}
