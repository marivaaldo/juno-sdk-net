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
    public class Address
    {
        /// <summary>
        /// Rua.
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// Número. Se não houver, envie N/A.
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Complemento.
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        /// Bairro.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// Cidade.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Estado em sigla de Unidade Federativa (UF).
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringNullableEnumConverter<AddressState>))]
        public AddressState State { get; set; }

        /// <summary>
        /// Código de endereçamento Postal no Brasil (CEP).
        /// </summary>
        [Required]
        [StringLength(8)]
        public string PostCode { get; set; }
    }
}
