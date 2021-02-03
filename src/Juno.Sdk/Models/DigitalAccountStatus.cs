using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum DigitalAccountStatus
    {
        ACTIVE,
        AWAITING_DOCUMENTS,
        VERIFYING,
        VERIFIED,
        BLOCKED,
        INACTIVE
    }
}
