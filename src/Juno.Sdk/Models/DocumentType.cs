using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum DocumentType
    {
        //
        // Pessoa Física

        ID,
        PROFESSIONAL_RECORD,
        ADDRESS_PROOF,
        SELFIE,

        //
        // Pessoa Jurídica

        EI_DOC,
        MEI_DOC,
        LTDA_DOC,
        CONSTITUTION_RECORD,
        EIRELI_DOC,
        CONTRACT_AGREEMENT,
        COMPANY_FORMATION_MEETING_MINUTES,
    }
}
