using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public enum BillPaymentStatus
    {
        SCHEDULED,
        REQUESTED,
        EXECUTED,
        AWAITING_EXECUTION,
        CANCELLED,
        FAILED,
        FAILED_INSUFFICIENT_FUNDS,
    }
}
