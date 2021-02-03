using Juno.Sdk.Models.Notifications;
using Juno.Sdk.Webhooks.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Webhooks
{
    public interface IWebhooksHandler :
        //
        // Queries

        IRequestHandler<GetWebhookSecretRequest, string>,

        //
        // Notifications

        INotificationHandler<DigitalAccountStatusChanged>,
        INotificationHandler<DocumentStatusChanged>,
        INotificationHandler<TransferStatusChanged>,
        INotificationHandler<P2PTransferStatusChanged>,
        INotificationHandler<ChargeStatusChanged>,
        INotificationHandler<ChargeReadConfirmation>,
        INotificationHandler<PaymentNotification>,
        INotificationHandler<BillPaymentStatusChanged>
    {
    }
}
