using Juno.Sdk.Models;
using Juno.Sdk.Models.Requests;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class ChargesService : AbstractService
    {
        public ChargesService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Emita cobranças para cartão de crédito ou boleto, com ou sem split de pagamento.
        ///
        /// Para cobranças na modalidade split, é possível informar um ou mais destinatários para divisão, na qual o recipientToken corresponde a cada conta digital envolvida.Caso o emissor delimitado no X-Resource-Token esteja envolvido na divisão, este também deve ser informado em um dos objetos desse array, além dos demais destinatários.
        ///
        /// Os parâmetros amount e percentage definem, respectivamente, a divisão do valor do split de maneira fixa ou percentual, não podendo ser enviados juntos na requisição.
        ///
        /// Caso a divisão de valores resulte em um número com mais de 2 casas decimais, a partilha de valores não ocorre de maneira exata, desse modo é preciso definir quem ficará com o remanescente em amountRemainder.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="charge"></param>
        /// <returns></returns>
        public ChargesResponse CreateCharge(string resourceToken, CreateChargeResource.CreateCharge charge)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Charges.CreateChargeRequest(Client.GetRequestContext());

            return request.Execute(new CreateChargeResource
            {
                ResourceToken = resourceToken,
                Charge = charge
            });
        }

        /// <summary>
        /// Muito útil na conciliação de recebimentos este método fornece uma listagem por página das cobranças de uma conta digital de acordo ao filtros disponíveis.
        ///
        /// Para avançar para as próximas páginas ou voltar para a página anterior deve ser utilizado os links previous e next devolvidos na resposta da chamada.
        ///
        /// Devolve 20 cobranças por páginas, podendo ser estendido até 100 páginas com pageSize=100.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ChargesResponse ListCharges(string resourceToken, ListChargeResource filter = null)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (filter == null)
                filter = new ListChargeResource();

            filter.ResourceToken = resourceToken;

            var request = new Requests.Charges.ListChargesRequest(Client.GetRequestContext());

            return request.Execute(filter);
        }

        /// <summary>
        /// Uma cobrança emitida emitida pode ser consultada a qualquer momento para que se obtenha seu estado atual.
        /// Para a consulta, utilize o ID da cobrança devolvido no momento da emissão.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="chargeId"></param>
        /// <returns></returns>
        public ChargeResource GetCharge(string resourceToken, string chargeId)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(chargeId))
            {
                throw new ArgumentNullException(nameof(chargeId));
            }

            var request = new Requests.Charges.GetChargeRequest(Client.GetRequestContext());

            return request.Execute(new GetChargeResource
            {
                ResourceToken = resourceToken,
                ChargeId = chargeId
            });
        }

        /// <summary>
        /// Uma cobrança emitida emitida pode ser cancelada a qualquer momento desde que não tenha recebido pagamento.
        /// Isso é válido para cobranças de qualquer paymentType que estejam como active, ou seja, em aberto.
        /// Para transações que tenham sido capturadas, seu cancelamento deve ser feito através desse recurso.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="chargeId"></param>
        public void CancelCharge(string resourceToken, string chargeId)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(chargeId))
            {
                throw new ArgumentNullException(nameof(chargeId));
            }

            var request = new Requests.Charges.CancelChargeRequest(Client.GetRequestContext());

            request.Execute(new CancelChargeResource
            {
                ResourceToken = resourceToken,
                ChargeId = chargeId
            });
        }

        /// <summary>
        /// Possibilita a atualização do split de cobranças que não tenham sido pagas.
        /// 
        /// Isso é válido para cobranças de qualquer paymentType que estejam como active ou com maxOverdueDays não expirado ou transações capturadas com status authorized, ou seja, em aberto.
        ///
        /// Mesmo que apenas um dos dados do objeto do split vá ser modificado como, por exemplo, o esquema de divisão ou destinatários da divisão, todo o objeto deve ser enviado na alteração.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="chargeId"></param>
        /// <param name="split"></param>
        public void UpdateChargeSplit(string resourceToken, string chargeId, List<Split> split)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(chargeId))
            {
                throw new ArgumentNullException(nameof(chargeId));
            }

            var request = new Requests.Charges.UpdateChargeSplitRequest(Client.GetRequestContext());

            request.Execute(new UpdateChargeSplitResource
            {
                ResourceToken = resourceToken,
                ChargeId = chargeId,
                Split = new UpdateChargeSplitResource.UpdateChargeSplit
                {
                    Split = split
                }
            });
        }
    }
}
