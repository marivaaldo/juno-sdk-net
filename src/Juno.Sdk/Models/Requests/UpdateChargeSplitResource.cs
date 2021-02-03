﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.Requests
{
    public class UpdateChargeSplitResource : IRequestResource
    {
        public class UpdateChargeSplit
        {
            public List<Split> Split { get; set; }
        }

        public string ResourceToken { get; set; }

        public string ChargeId { get; set; }

        public UpdateChargeSplit Split { get; set; }
    }
}
