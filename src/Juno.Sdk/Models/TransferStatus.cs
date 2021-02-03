using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum TransferStatus
    {
        REQUESTED,
        NEEDS_CHECK,
        CHECK_FAILED,
        EXECUTED,
        AWAITING_EXECUTION,
        REJECTED,
        INVALID_BANK_ACCOUNT,
        CANCELED,
    }
}
