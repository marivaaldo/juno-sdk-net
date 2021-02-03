using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class BalancesService : AbstractService
    {
        public BalancesService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Consulta o saldo de uma Conta Digital Juno.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <returns></returns>
        public Balance GetBalance(string resourceToken)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Balances.GetBalanceRequest(Client.GetRequestContext());;

            return request.Execute(resourceToken);
        }
    }
}
