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
    public class DocumentsService : AbstractService
    {
        public DocumentsService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Por padrão, Contas Digitais necessitam encaminhar documentos para validação do cadastro.
        /// Consultar quais são os documentos esperados para a conta.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <returns></returns>
        public DocumentsResponse ListDocuments(string resourceToken)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Documents.ListDocumentsRequest(Client.GetRequestContext());;

            return request.Execute(resourceToken);
        }

        /// <summary>
        /// Contas Digitais que não foram criadas com autoApprove habilitado passam por uma validação do recebimento dos documentos relacionados ao seu tipo de empresa.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public Document GetDocument(string resourceToken, string documentId)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Documents.GetDocumentRequest(Client.GetRequestContext());;

            return request.Execute(new Models.Requests.DocumentResource
            {
                ResourceToken = resourceToken,
                DocumentId = documentId
            });
        }

        /// <summary>
        /// Realiza o upload de arquivos relacionados ao documento identificado por meio de seu ID específico.
        /// Extensões de arquivos aceitas: pdf, doc, docx, jpg, jpeg, png, bpm, tiff.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public Document PostDocument(PostDocumentResource document)
        {
            if (string.IsNullOrWhiteSpace(document.ResourceToken))
            {
                throw new ArgumentNullException(nameof(document.ResourceToken));
            }

            var request = new Requests.Documents.PostDocumentRequest(Client.GetRequestContext());;

            return request.Execute(document);
        }

        /// <summary>
        /// Realiza o upload de um arquivo relacionado ao documento. Criptografa o conteúdo do arquivo antes de enviá-lo.
        /// Esta versão utiliza a especificação JWE para a geração de um token criptografado, o qual contém um payload JSON com o nome do arquivo e seu conteúdo no formato base64.
        /// Para garantir performance durante a requisição, o payload JSON deve ser compactado(baseado na especificação JWE), e o token JWE em si também deve ser compactado utilizando a especificação GZIP, antes de ser submetido ao serviço.
        /// Informações relacionadas ao algoritmo de criptografia e exemplos de utilização podem ser encontrados nas referências da API.
        /// Extensões de arquivos aceitas: pdf, doc, docx, jpg, jpeg, png, bpm, tiff.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public Document PostEncryptedDocument(PostEncryptedDocument document)
        {
            if (string.IsNullOrWhiteSpace(document.ResourceToken))
            {
                throw new ArgumentNullException(nameof(document.ResourceToken));
            }

            var request = new Requests.Documents.PostEncryptedDocumentRequest(Client.GetRequestContext());;

            return request.Execute(document);
        }
    }
}
