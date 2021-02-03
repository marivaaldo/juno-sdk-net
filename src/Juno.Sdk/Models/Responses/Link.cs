using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Responses
{
    public class LinkChild
    {
        public string Href { get; set; }
    }

    public class Link
    {

        public LinkChild Self { get; set; }
    }

    public class PaginatedLink : Link
    {
        public LinkChild Previous { get; set; }

        public LinkChild Next { get; set; }
    }
}
