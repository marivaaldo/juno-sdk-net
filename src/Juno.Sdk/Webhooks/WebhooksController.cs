using Juno.Sdk.Models;
using Juno.Sdk.Models.Notifications;
using Juno.Sdk.Webhooks.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Juno.Sdk.Webhooks
{
    [ApiController]
    [Route("juno/wh")]
    public class WebhooksController : ControllerBase
    {
        #region Fields

        private const string XSignatureHeader = "X-Signature";

        public static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true,
        };

        private MediatR.IMediator Mediator { get; }

        #endregion

        public WebhooksController(MediatR.IMediator mediator)
        {
            Mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("notifications")]
        public async Task<ActionResult> Notifications([FromBody] dynamic body)
        {
            string contents = body.ToString();

            var validSignature = await ValidateSignatureAsync(contents);

            if (!validSignature)
                return BadRequest();

            var notification = GetNotification(contents);

            if (notification == null)
                return BadRequest();

            await Mediator.Publish(notification);

            return Ok();
        }

        #region Private Methods

        private async Task<bool> ValidateSignatureAsync(string contents)
        {
            if (string.IsNullOrWhiteSpace(contents))
                return false;

            var secret = await Mediator.Send(new GetWebhookSecretRequest
            {
                Parameters = Request.Query.ToDictionary(o => o.Key, o => o.Value.ToList())
            });
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(secret));

            var hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(contents));

            var signature = Request.Headers[XSignatureHeader].ToString();
            var localSignature = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            bool validSignature = signature.Equals(localSignature);

            return validSignature;
        }

        private static INotification GetNotification(string contents)
        {
            var defaultObj = JsonSerializer.Deserialize<DefaultNotification>(contents, jsonSerializerOptions);

            INotification notification = defaultObj.EventType switch
            {
                EventName.DIGITAL_ACCOUNT_STATUS_CHANGED => JsonSerializer.Deserialize<DigitalAccountStatusChanged>(contents, jsonSerializerOptions),
                EventName.DOCUMENT_STATUS_CHANGED => JsonSerializer.Deserialize<DocumentStatusChanged>(contents, jsonSerializerOptions),
                EventName.TRANSFER_STATUS_CHANGED => JsonSerializer.Deserialize<TransferStatusChanged>(contents, jsonSerializerOptions),
                EventName.P2P_TRANSFER_STATUS_CHANGED => JsonSerializer.Deserialize<P2PTransferStatusChanged>(contents, jsonSerializerOptions),
                EventName.CHARGE_STATUS_CHANGED => JsonSerializer.Deserialize<ChargeStatusChanged>(contents, jsonSerializerOptions),
                EventName.CHARGE_READ_CONFIRMATION => JsonSerializer.Deserialize<ChargeReadConfirmation>(contents, jsonSerializerOptions),
                EventName.PAYMENT_NOTIFICATION => JsonSerializer.Deserialize<PaymentNotification>(contents, jsonSerializerOptions),
                EventName.BILL_PAYMENT_STATUS_CHANGED => JsonSerializer.Deserialize<BillPaymentStatusChanged>(contents, jsonSerializerOptions),
                _ => null
            };

            return notification;
        }

        #endregion
    }
}
