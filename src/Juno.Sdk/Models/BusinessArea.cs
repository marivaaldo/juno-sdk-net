using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class BusinessArea
    {
        public long Code { get; set; }

        public string Activity { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return $"[{Code}] {Activity} - {Category}";
        }
    }
}
