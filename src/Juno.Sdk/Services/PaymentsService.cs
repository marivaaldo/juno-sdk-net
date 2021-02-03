using Juno.Sdk.Models;
using Juno.Sdk.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    /// <summary>
    /// Pagamentos utilizando cartão de crédito / checkout transparente.
    /// 
    /// Bandeiras de cartões aceitas: Master, Visa, Elo, Amex, Hiper, Discovery, JCB, Diners e Aura.
    /// </summary>
    public class PaymentsService : AbstractService
    {
        public PaymentsService(JunoClient client) : base(client)
        {
        }

        /// <summary>
        /// Ao ser utilizado, o recurso permite que o cartão utilizado nesse processo seja tokenizado, ou seja, tenha seus dados convertido em uma um ID que pode ser armazenado em seguida para ser utilizado em funcionalidades do próprio sistema como armazenamento do cartão para compras futuras.
        ///
        /// Requer permissão avançada para ser utilizada.Caso seu case de negócio atenda a este cenário, entre em contato com a Juno para solicitar permissão.
        /// </summary>
        /// <param name="creditCardHash"></param>
        /// <returns></returns>
        public CreditCardToken CreditCardTokenization(string creditCardHash)
        {
            if (string.IsNullOrWhiteSpace(creditCardHash))
            {
                throw new ArgumentNullException(nameof(creditCardHash));
            }

            var request = new Requests.Payments.CreditCardTokenizationRequest(Client.GetRequestContext());

            return request.Execute(creditCardHash);
        }

        /// <summary>
        /// Para cobranças cujo paymentType é <see cref="PaymentType.CREDIT_CARD"/> podem ser pagas logo em seguida sua criação.
        ///
        /// Através desse endpoint você cria um pagamento para a cobrança emitida identificada a partir de seu chargeId retornado no momento de sua geração.
        /// 
        /// Este recurso permite a captura tardia de pagamento, ou seja, através dele é possível obter e segurar o valor da transação no saldo do cartão em questão sem concluír este pagamento efetivamente, muito utilizado na prestação de serviços.
        /// 
        /// Para utilizar o recurso dessa forma é preciso que o parâmetro <see cref="BillingForPayment.Delayed"/> receba o valor true, resultando em um pagamento capturado que recebe o status <see cref="PaymentStatus.AUTHORIZED"/>. Caso contrário, o pagamento será efetuado normalmente com status <see cref="PaymentStatus.CONFIRMED"/>.
        ///
        /// IMPORTANTE: caso o pagamento tenha sido recusado, faça uma nova tentativa utilizando o chargeId da cobrança já criada. Não é necessário criar uma nova cobrança para este processo.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        public PaymentResponse CreatePayment(string resourceToken, Models.Requests.CreatePaymentResource.CreatePayment payment)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            var request = new Requests.Payments.CreatePaymentRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.CreatePaymentResource
            {
                ResourceToken = resourceToken,
                Payment = payment
            });
        }

        /// <summary>
        /// Faz o estorno total ou parcial de transações de cartão de crédito.
        /// 
        /// Afeta todas as cobranças geradas e todos os pagamentos já realizados, até mesmo para os casos em que o pagamento tenha sido parcelado.
        ///
        /// Para estorno parcial, a quantidade definida em amount deve ser menor que o valor total da transação.Caso não seja passado nenhum valor nesse parâmetro, será feito o estorno total da transação.
        /// 
        /// Se no endpoint não for passado o valor, vai ser estornado o total, se for menor o parcial.
        /// 
        /// Caso a cobrança indicada tenha sido criada com o split, no momento do estorno deve ser definido novamente no body os destinatários do split.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="paymentId"></param>
        /// <param name="refund"></param>
        /// <returns></returns>
        public RefundCreditCardPaymentResponse RefundCreditCardPayment(string resourceToken, string paymentId, Models.Requests.RefundCreditCardPaymentResource.RefundCreditCardPayment refund)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(paymentId))
            {
                throw new ArgumentNullException(nameof(paymentId));
            }

            if (refund == null)
            {
                throw new ArgumentNullException(nameof(refund));
            }

            var request = new Requests.Payments.RefundCreditCardPaymentRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.RefundCreditCardPaymentResource
            {
                ResourceToken = resourceToken,
                PaymentId = paymentId,
                Refund = refund
            });
        }

        /// <summary>
        /// Faz a captura total ou parcial de transações previamente autorizadas no cartão de crédito.
        /// 
        /// Afeta todas as cobranças geradas, até mesmo para os casos em que o pagamento tenha sido parcelado.
        ///
        /// Para captura parcial, a quantidade definida em <see cref="Models.Requests.CaptureCreditCardPaymentResource.CaptureCreditCardPayment.Amount"/> deve ser menor que o valor total da transação. Caso não seja passado nenhum valor nesse parâmetro, será feita a captura total da transação.
        /// </summary>
        /// <param name="resourceToken"></param>
        /// <param name="paymentId"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        public PaymentResponse CaptureCreditCardPayment(string resourceToken, string paymentId, Models.Requests.CaptureCreditCardPaymentResource.CaptureCreditCardPayment payment)
        {
            if (string.IsNullOrWhiteSpace(resourceToken))
            {
                throw new ArgumentNullException(nameof(resourceToken));
            }

            if (string.IsNullOrWhiteSpace(paymentId))
            {
                throw new ArgumentNullException(nameof(paymentId));
            }

            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            var request = new Requests.Payments.CaptureCreditCardPaymentRequest(Client.GetRequestContext());

            return request.Execute(new Models.Requests.CaptureCreditCardPaymentResource
            {
                ResourceToken = resourceToken,
                PaymentId = paymentId,
                Payment = payment
            });
        }
    }
}
