using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.Home.ValueProviders;

namespace Threax.Home.InputModels
{
    [HalModel]
    public class ThermostatTempInput
    {
        [ValueProvider(typeof(TemperatureProvider))]
        public int CoolTemp { get; set; }

        [ValueProvider(typeof(TemperatureProvider))]
        public int HeatTemp { get; set; }
    }
}
