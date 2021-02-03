using Juno.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class ListChargeResource : IRequestResource
    {
        public enum ListChargeResourceOrderBy
        {
            Id,
            DueDate,
            Amount,
            PaymentDate
        }

        [JsonIgnore]
        public string ResourceToken { get; set; }

        /// <summary>
        /// Busca pela criação da cobrança a partir dessa data
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? CreatedOnStart { get; set; }

        /// <summary>
        /// Busca pela criação da cobrança até
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? CreatedOnEnd { get; set; }

        /// <summary>
        /// Busca por vencimentos a partir dessa data
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? DueDateStart { get; set; }

        /// <summary>
        /// Busca por vencimentos a partir até essa data
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? DueDateEnd { get; set; }

        /// <summary>
        /// Busca por pagamentos a partir dessa data
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? PaymentDateStart { get; set; }

        /// <summary>
        /// Busca por pagamentos até essa data
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? PaymentDateEnd { get; set; }

        /// <summary>
        /// Mostra cobranças que não foram ou estão arquivadas
        /// </summary>
        public bool? ShowUnarchived { get; set; }

        /// <summary>
        /// Mostra cobranças que foram ou estão arquivadas
        /// </summary>
        public bool? ShowArchived { get; set; }

        /// <summary>
        /// Mostra cobranças vencidas
        /// </summary>
        public bool? ShowDue { get; set; }

        /// <summary>
        /// Mostra cobranças que não estão vencidas
        /// </summary>
        public bool? ShowNotDue { get; set; }

        /// <summary>
        /// Mostra cobranças pagas
        /// </summary>
        public bool? ShowPaid { get; set; }

        /// <summary>
        /// Mostra cobranças que não estão pagas
        /// </summary>
        public bool? ShowNotPaid { get; set; }

        /// <summary>
        /// Mostra cobranças canceladas
        /// </summary>
        public bool? ShowCancelled { get; set; }

        /// <summary>
        /// Mostra cobranças que não estão canceladas
        /// </summary>
        public bool? ShowNotCancelled { get; set; }

        /// <summary>
        /// Mostra cobranças que foram baixadas manualmente
        /// </summary>
        public bool? ShowManualReconciliation { get; set; }

        /// <summary>
        /// Mostra cobranças que não foram baixadas manualmente
        /// </summary>
        public bool? ShowNotManualReconciliation { get; set; }

        /// <summary>
        /// Mostra cobranças que tiveram falha no pagamento. (Checkout transparente)
        /// </summary>
        public bool? ShowNotFailed { get; set; }

        /// <summary>
        /// Ordenação cobranças pelos filtros
        /// </summary>
        [JsonConverter(typeof(StringNullableEnumConverter<ListChargeResourceOrderBy?>))]
        public ListChargeResourceOrderBy? OrderBy { get; set; }

        /// <summary>
        /// Ordenação cobranças ascendente ou descentente
        /// </summary>
        public bool? OrderAsc { get; set; }

        /// <summary>
        /// Quantidade de cobranças por página
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Número identificador da página
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Define a partir de qual objeto charge será feita a busca
        /// </summary>
        public string FirstObjectId { get; set; }

        /// <summary>
        /// Define a partir de qual valor será feita a busca
        /// </summary>
        public string FirstValue { get; set; }

        /// <summary>
        /// Define até qual objeto charge será feita a busca
        /// </summary>
        public string LastObjectId { get; set; }

        /// <summary>
        /// Define até qual valor será feita a busca
        /// </summary>
        public string LastValue { get; set; }
    }
}
