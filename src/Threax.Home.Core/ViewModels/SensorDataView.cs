using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Core.ViewModels
{
    [HalModel]
    [HalSelfLink]
    public class SensorDataView
    {
        public float Value { get; set; }

        public Units Units { get; set; }
    }
}
