﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class DocumentResource : IRequestResource
    {
        public string ResourceToken { get; set; }

        public string DocumentId { get; set; }
    }
}
