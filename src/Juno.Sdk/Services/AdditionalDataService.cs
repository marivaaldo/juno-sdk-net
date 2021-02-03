using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class AdditionalDataService : AbstractService
    {
        public AdditionalDataService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Utilize esse método para retornar a lista de bancos disponíveis para recebimento de transferências na Juno.
        /// </summary>
        /// <returns></returns>
        public Models.Responses.BanksResponse ListBanks()
        {
            var request = new Requests.AdditionalData.ListBanksRequest(Client.GetRequestContext());

            return request.Execute();
        }

        /// <summary>
        /// Utilize esse método para retornar a lista de tipos de empresas disponíveis na plataforma Juno que podem ser utilizadas na criação de uma Conta Digital.
        /// </summary>
        /// <returns></returns>
        public Models.Responses.CompanyTypesResponse ListCompanyTypes()
        {
            var request = new Requests.AdditionalData.ListCompanyTypesRequest(Client.GetRequestContext());;

            return request.Execute();
        }

        /// <summary>
        /// Traz a lista de áreas de negócios disponíveis na plataforma Juno que podem ser utilizadas na criação de uma Conta Digital.
        /// </summary>
        /// <returns></returns>
        public Models.Responses.BusinessAreasResponse ListBusinessAreas()
        {
            var request = new Requests.AdditionalData.ListBusinessAreasRequest(Client.GetRequestContext());;

            return request.Execute();
        }
    }
}
