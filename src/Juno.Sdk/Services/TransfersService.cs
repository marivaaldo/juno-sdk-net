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
    public class TransfersService : AbstractService
    {
        public TransfersService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Através deste serviço é possível efetuar transferências para a Conta Bancária padrão do cliente, para Contas Bancárias de terceiros ou para Contas Digitais Juno.
        /// </summary>
        /// <param name="resourceToken">Conta digital de origem</param>
        /// <param name="transferRequest">Dados da transferência</param>
        /// <returns></returns>
        public TransferResponse NewTransfer(string resourceToken, ITransferRequest transferRequest)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Transfers.NewTransferRequest(Client.GetRequestContext());;

            return request.Execute(new TransferResource()
            {
                ResourceToken = resourceToken,
                Request = transferRequest,
            });
        }
    }
}
