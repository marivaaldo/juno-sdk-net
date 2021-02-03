using Juno.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class DigitalAccountsService : AbstractService
    {
        public DigitalAccountsService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Cria uma conta digital Juno.
        /// 
        /// As contas criadas são do tipo Payment Account e os dados retornados na criação das contas devem ser armazenados para fins de manipulação da conta recém-criada.
        /// 
        /// Importante: O acesso e manipulação da conta se dá apenas via API. Não possuem login e senha.
        /// </summary>
        /// <param name="digitalAccount"></param>
        /// <returns></returns>
        public Models.Responses.DigitalAccountResponse CreateDigitalAccount(DigitalAccount digitalAccount)
        {
            digitalAccount.TradingName = null;

            var request = new Requests.DigitalAccounts.CreateDigitalAccountRequest(Client.GetRequestContext());

            return request.Execute(digitalAccount);
        }

        /// <summary>
        /// Retorna dados da conta digital.
        /// </summary>
        /// <param name="resourceToken">Token da conta para recuperar.</param>
        /// <returns></returns>
        public Models.Responses.DigitalAccountResponse GetDigitalAccount(string resourceToken)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.DigitalAccounts.GetDigitalAccountRequest(Client.GetRequestContext()); ;

            return request.Execute(resourceToken);
        }

        /// <summary>
        /// Realiza a atualização de dados de uma conta digital do tipo pagamento.
        ///
        /// As seguintes informações serão atualizadas durante a requisição:
        ///
        ///     Email de contato e Telefone
        ///     Informações do Endereço
        ///     Dados bancários
        /// 
        /// Alguns dados não serão atualizados durante a requisição, pois dependem de uma análise pelas áreas internas da Juno, sendo eles:
        ///
        ///     Nome, Data de Nascimento e Documento de Identificação (CPF/CNPJ)
        ///     Dados do representante legal
        ///     Razão Social
        ///     Área e Linha de Negócio
        ///     Tipo de Empresa
        /// 
        /// Nossa equipe será informada sobre as alterações e irá efetivá-las em breve.
        ///
        /// Os dados informados na requisição são opcionais, e só serão atualizados caso sejam enviados.
        ///
        /// Importante: para atualização de qualquer um dos dados que compõem o objeto dessa request, todos os dados devem ser informados, caso contrário a alteração destes campos será ignorada.
        /// </summary>
        /// <param name="digitalAccount"></param>
        /// <returns></returns>
        public Models.Responses.DigitalAccountResponse UpdateDigitalAccount(DigitalAccount digitalAccount)
        {
            digitalAccount.Type = null;
            digitalAccount.Document = null;
            digitalAccount.EmailOptOut = null;
            digitalAccount.AutoApprove = null;
            digitalAccount.AutoTransfer = null;

            var request = new Requests.DigitalAccounts.UpdateDigitalAccountRequest(Client.GetRequestContext()); ;

            return request.Execute(digitalAccount);
        }
    }
}
