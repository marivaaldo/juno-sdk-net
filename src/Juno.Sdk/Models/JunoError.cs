using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class JunoError
    {
        public DateTime Timestamp { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }

        public string Path { get; set; }

        public List<Detail> Details { get; set; }

        public JunoError() { }

        public JunoError(int status, string error)
        {
            Status = status;
            Error = error;
        }

        public class Detail
        {
            public string Field { get; set; }

            public string Message { get; set; }

            public string ErrorCode { get; set; }
        }
    }
}
