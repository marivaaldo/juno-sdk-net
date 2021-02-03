using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models
{
    public class Pix
    {
        public string Id { get; set; }

        public string QrcodeInBase64 { get; set; }

        public string ImageInBase64 { get; set; }
    }
}
