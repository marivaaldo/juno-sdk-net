using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class JunoRequestException : Exception
    {
        public JunoError Error { get; }

        public JunoRequestException(string message, JunoError error)
            : base(message)
        {
        }
        public JunoRequestException(string message, JunoError error, Exception innerException)
            : base(message, innerException)
        {
            Error = error;
        }
    }
}
