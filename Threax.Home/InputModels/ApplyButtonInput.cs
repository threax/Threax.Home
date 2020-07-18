using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.InputModels
{
    [HalModel]
    [CacheEndpointDoc]
    public class ApplyButtonInput
    {
        public Guid ButtonStateId { get; set; }
    }
}
