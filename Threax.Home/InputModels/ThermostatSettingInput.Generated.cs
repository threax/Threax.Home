using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.InputModels 
{
    [HalModel]
    public partial class ThermostatSettingInput : IThermostatSetting
    {
        [UiOrder(0, 13)]
        public String Label { get; set; }

        [UiOrder(0, 16)]
        public int Order { get; set; }

        [UiOrder(0, 19)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.TemperatureProvider))]
        public int CoolTemp { get; set; }

        [UiOrder(0, 23)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.TemperatureProvider))]
        public int HeatTemp { get; set; }

        [UiOrder(0, 27)]
        public bool On { get; set; }

        [Display(Name = "Thermostat")]
        [UiOrder(0, 30)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.ThermostatProvider))]
        public Guid ThermostatId { get; set; }

    }
}
