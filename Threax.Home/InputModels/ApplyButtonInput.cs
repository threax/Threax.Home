using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.InputModels
{
    [HalModel]
    public class ApplyButtonInput
    {
        public Guid ButtonStateId { get; set; }
    }
}
