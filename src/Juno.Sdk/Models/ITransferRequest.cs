using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public interface ITransferRequest
    {
        TransferRequestType Type { get; }
    }

    public enum TransferRequestType
    {
        P2P,

        DEFAULT_BANK_ACCOUNT,

        BANK_ACCOUNT
    }
}
