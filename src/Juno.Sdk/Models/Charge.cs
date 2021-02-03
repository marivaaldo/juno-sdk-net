using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Charge
    {
        /// <summary>
        /// Chave Pix aleatória associada a conta digital referenciada em X-Resource-Token (Obrigatória para o tipo de pagamento BOLETO_PIX).
        /// </summary>
        [StringLength(36)]
        public string PixKey { get; set; }

        /// <summary>
        /// Descrição da cobrança
        /// </summary>
        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        /// <summary>
        /// Lista de references atrelada a cada cobrança gerada. O número de itens deve ser igual ao número de parcelas.
        /// </summary>
        public List<string> References { get; set; }

        /// <summary>
        /// Valor total da transação. Requer uso do parâmetro <see cref="Installments"/>. Se utilizado, não deverá ser utilizado <see cref="Amount"/>.
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Valor total da parcela. O valor será aplicado para cada parcela. Se utilizado, não deverá ser utilizado <see cref="TotalAmount"/>.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Data de vencimento.
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Número de parcelas.
        /// 
        /// Depende do tipo de pagamento:
        ///     BOLETO: até 24 parcelas;
        ///     CREDIT_CARD: até 12 parcelas;
        ///     BOLETO_PIX: apenas 1 parcela.
        ///
        /// Se houver mais de um tipo de pagamento, deve-se confirgurar o número de parcelas de acordo com o tipo que possui o menor número de parcelas possível. Exemplos:
        ///     BOLETO, CREDIT_CARD: até 12 parcelas;
        ///     BOLETO_PIX, CREDIT_CARD: apenas 1 parcela.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Número de dias permitido para pagamento após o vencimento. Não disponível para BOLETO_PIX.
        /// </summary>
        public int? MaxOverdueDays { get; set; }

        /// <summary>
        /// Multa para pagamento após o vencimento. Recebe valores de 0.00 a 20.00. Só é efetivo se <see cref="MaxOverdueDays"/> for maior que zero. Não disponível para BOLETO_PIX.
        /// </summary>
        [Range(0, 20)]
        public int? Fine { get; set; }

        /// <summary>
        /// Juros ao mês. Recebe valores de 0.00 a 20.00. Só é efetivo se <see cref="MaxOverdueDays"/> for maior que zero. O valor inserido é dividido pelo número de dias para cobrança de juros diária. Não disponível para BOLETO_PIX.
        /// </summary>
        [Range(0.00, 20.00)]
        public decimal? Interest { get; set; }

        /// <summary>
        /// Valor absoluto de desconto. Não disponível para BOLETO_PIX.
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Número de dias de desconto. Não disponível para BOLETO_PIX.
        /// </summary>
        public int? DiscountDays { get; set; }

        /// <summary>
        /// Tipos de pagamento permitidos BOLETO, BOLETO_PIX e CREDIT_CARD. 
        /// Para checkout transparente, deve receber obrigatoriamente o tipo CREDIT_CARD.
        ///
        /// Arranjos de tipos de pagamentos permitidos:
        ///     BOLETO
        ///     BOLETO_PIX
        ///     CREDIT_CARD
        ///     BOLETO, CREDIT_CARD
        ///     BOLETO_PIX, CREDIT_CARD
        ///     
        /// Arranjos de tipos de pagamentos NÃO permitidos:
        ///     BOLETO, BOLETO_PIX
        /// </summary>
        [JsonConverter(typeof(ListStringNullableEnumConverter<List<PaymentType>, PaymentType>))]
        public List<PaymentType> PaymentTypes { get; set; }

        /// <summary>
        /// Define se a cobrança, quando paga, terá sua liberação de seu valor de recebimento adiantada. Valido apenas para cartão de crédito. Se false, o pagamento não será antecipado.
        /// </summary>
        public bool PaymentAdvance { get; set; } = false;

        /// <summary>
        /// Define o esquema de taxas alternativo para uma cobrança específica.
        /// Para cobranças criadas com o objeto <see cref="Split"/>, a taxa da emissão fica a cargo da conta que recebe true no <see cref="Split.ChargeFee"/>.
        /// </summary>
        public string FeeSchemaToken { get; set; }

        /// <summary>
        /// Divisão de valores de recebimento
        /// </summary>
        public List<Split> Split { get; set; }
    }
}
