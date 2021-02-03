using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Split
    {
        /// <summary>
        /// Define os destinatários do split.
        /// Importante: Caso o emissor da cobrança seja também destinatário na divisão de valores, seu x-resource-token também deve ser definido.
        /// </summary>
        public string RecipientToken { get; set; }

        /// <summary>
        /// Define o valor fixo que a conta vai receber. Caso seja enviado, não será aceito o parâmetro <see cref="Percentage"/> no objeto split.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Define o valor percentual que a conta vai receber. Caso seja enviado, não será aceito o parâmetro <see cref="Amount"/> no objeto split.
        /// </summary>
        public decimal? Percentage { get; set; }

        /// <summary>
        /// Indica quem recebe o valor restante em caso de uma divisão do valor total da transação.
        /// </summary>
        public bool AmountRemainder { get; set; } = true;

        /// <summary>
        /// Indica se somente um recebedor será taxado ou se as taxas serão divididas proporcionalmente entre todos os recebedores.
        /// </summary>
        public bool ChargeFee { get; set; } = true;
    }
}
