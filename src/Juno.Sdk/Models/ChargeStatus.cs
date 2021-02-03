using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum ChargeStatus
    {
        ACTIVE,
        CANCELLED,
        MANUAL_RECONCILIATION,
        FAILED,
        PAID,
    }
}
