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
    public class DigitalAccount
    {
        /// <value>DigitalAccountType.PAYMENT</value>
        [Required]
        [JsonConverter(typeof(StringNullableEnumConverter<DigitalAccountType?>))]
        public DigitalAccountType? Type { get; set; } = DigitalAccountType.PAYMENT;

        /// <summary>
        /// Nome da conta digital.
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Nome fantasia.
        /// </summary>
        [StringLength(80)]
        public string TradingName { get; set; }

        /// <summary>
        /// CPF/CNPJ da conta digital. Envie sem ponto ou traço.
        /// </summary>
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string Document { get; set; }

        /// <summary>
        /// E-mail da conta digital.
        /// </summary>
        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Data de nascimento. Obrigatório para contas PF.
        /// </summary>
        [DateTimeNullableFormatConverter("yyyy-MM-dd")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Telefone da conta digital.
        /// </summary>
        [Required]
        [StringLength(16)]
        public string Phone { get; set; }

        /// <summary>
        /// Define a área de negócio da empresa. Para consultar os valores permitidos, consulte <see cref="https://dev.juno.com.br/api/v2#operation/getBusinessAreas" />.
        /// </summary>
        [Required]
        public long BusinessArea { get; set; }

        /// <summary>
        /// Define a linha de negócio da empresa. Campo de livre preenchimento.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LinesOfBusiness { get; set; }

        /// <summary>
        /// Define a natureza de negócio. Obrigatório para contas PJ. Para consultar os valores permitidos, consulte <see cref="https://dev.juno.com.br/api/v2#operation/getCompanyTypes"/>
        /// </summary>
        [JsonConverter(typeof(StringNullableEnumConverter<CompanyType?>))]
        public CompanyType? CompanyType { get; set; }

        /// <summary>
        /// Representante Legal. Obrigatório para contas PJ.
        /// </summary>
        public LegalRepresentative LegalRepresentative { get; set; }

        /// <summary>
        /// Endereço.
        /// </summary>
        [Required]
        public Address Address { get; set; }

        /// <summary>
        /// Conta Bancária.
        /// </summary>
        [Required]
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Define se a conta criada receberá ou não quaisquer emails Juno como os enviados nas operações de emissão de cobranças, trasnferências, entre outros. Requer permissão avançada. Útil para comunicações com seu cliente diretamente pela sua aplicação.
        /// </summary>
        public bool? EmailOptOut { get; set; }

        /// <summary>
        /// Define se a conta criada será aprovada automaticamente ou não. Ou seja, se a conta irá ou não passar por checagem de documentação para aprovação do cadastro Requer permissão avançada.
        /// </summary>
        public bool? AutoApprove { get; set; }

        /// <summary>
        /// Define se as transferências da conta serão feitas automaticamente. Caso haja saldo na conta digital em questão, a transferência será feita todos os dias. Requer permissão avançada.
        /// </summary>
        public bool? AutoTransfer { get; set; }
    }
}
