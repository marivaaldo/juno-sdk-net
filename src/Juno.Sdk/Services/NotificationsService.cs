using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class NotificationsService : AbstractService
    {
        public NotificationsService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Traz a lista de tipos de eventos disponíveis na plataforma Juno.
        /// Os itens retornados são os que estão disponíveis para serem subescritos pelos webhooks que vierem a ser cadastrados.
        /// Atenção: Apenas os eventos habilitados serão enviados para os webhooks cadastrados.
        /// </summary>
        /// <returns></returns>
        public EventTypeResponse ListEventTypes()
        {
            var request = new Requests.Notifications.ListEventTypesRequest(Client.GetRequestContext());

            return request.Execute();
        }

        /// <summary>
        /// Cadastre um ou mais webhooks para receber os tipos de notificação subescritos nos eventos disponíveis.
        /// Os webhooks e inscrição a um evento precisa ser única por recurso, o que significa que cada conta digital DEVE ter seu próprio webhook registrado.Não há webhook global.Você pode usar o endpoint para todos os registros de webhook, com ou sem parametros de cadeia de consulta.
        /// Atenção: O webhook deve usar HTTP sobre SSL encriptado e começar com https://.
        /// Não é possível se inscrever em um evento que já tenha esteja com uma inscrição ativa. Este deve ser desativado para que uma nova inscrição seja feita.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="webhook"></param>
        /// <returns></returns>
        public Webhook CreateWebhook(string resourceToken, Models.Requests.CreateWebhookResource.CreateWebhook webhook)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(webhook.Url))
            {
                throw new ArgumentNullException(nameof(webhook.Url));
            }

            if (webhook.EventTypes == null || webhook.EventTypes.Count == 0)
            {
                throw new ArgumentNullException(nameof(webhook.EventTypes));
            }

            var request = new Requests.Notifications.CreateWebhookRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.CreateWebhookResource()
            {
                ResourceToken = resourceToken,
                Webhook = webhook
            });
        }

        /// <summary>
        /// Retorna uma lista completa dos webhooks cadastrados para a conta digital e suas respectivas inscrições.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <returns></returns>
        public WebhooksResponse ListWebhooks(string resourceToken)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            var request = new Requests.Notifications.ListWebhooksRequest(Client.GetRequestContext());

            return request.Execute(resourceToken);
        }

        /// <summary>
        /// Retorna o webhook específicado.
        /// A partir do id específico retornado no momento da criação deste webhook, faça a consulta deste e verifique o estado atual e o evento para o qual foi inscrito.
        /// Caso o estado e/ou o tipo de evento esteja diferente do esperado, atualize o webhook.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="webhookId"></param>
        /// <returns></returns>
        public Webhook GetWebhook(string resourceToken, string webhookId)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(webhookId))
            {
                throw new ArgumentNullException(nameof(webhookId));
            }

            var request = new Requests.Notifications.GetWebhookRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.WebhookResource
            {
                ResourceToken = resourceToken,
                WebhookId = webhookId
            });

        }

        /// <summary>
        /// Atualize os campos status e eventTypes dos webhooks cadastradados.
        /// Ao menos um dos campos precisa ser mudado, não sendo necessário a mudança de ambos ao mesmo tempo.Entretanto, envie ambos os campos mesmo que apenas um destes venha a ser modificado.
        /// A url do Webhook não pode ser modificada.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="webhook"></param>
        /// <returns></returns>
        public Webhook UpdateWebhook(string resourceToken, string webhookId, Models.Requests.UpdateWebhookResource.UpdateWebhook webhook)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (webhook.EventTypes == null || webhook.EventTypes.Count == 0)
            {
                throw new ArgumentNullException(nameof(webhook.EventTypes));
            }

            var request = new Requests.Notifications.UpdateWebhookRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.UpdateWebhookResource()
            {
                ResourceToken = resourceToken,
                WebhookId = webhookId,
                Webhook = webhook,
            });
        }

        /// <summary>
        /// Deleta um webhook.
        /// Esta operação não deleta os eventos que já foram despachados para os webhooks listados.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="webhookId"></param>
        public void DeleteWebhook(string resourceToken, string webhookId)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(webhookId))
            {
                throw new ArgumentNullException(nameof(webhookId));
            }

            var request = new Requests.Notifications.DeleteWebhookRequest(Client.GetRequestContext());

            request.Execute(new Models.Requests.WebhookResource
            {
                ResourceToken = resourceToken,
                WebhookId = webhookId
            });
        }
    }
}
