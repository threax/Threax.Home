using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;
using Threax.Home.ValueProviders;

namespace Threax.Home.ModelSchemas
{
    public class ThermostatSetting
    {
        [UiOrder]
        public String Label { get; set; }

        [UiOrder]
        public int Order { get; set; }

        [UiOrder]
        [DefineValueProvider(typeof(TemperatureProvider))]
        public int CoolTemp { get; set; }

        [UiOrder]
        [DefineValueProvider(typeof(TemperatureProvider))]
        public int HeatTemp { get; set; }

        [UiOrder]
        public bool On { get; set; }

        [UiOrder]
        [DefineValueProvider(typeof(ThermostatProvider))]
        [Queryable]
        [Display(Name = "Thermostat")]
        public Guid ThermostatId { get; set; }
    }
}
