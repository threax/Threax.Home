using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.Home.ViewModels 
{
       public partial class ThermostatSetting : IThermostatSetting, IThermostatSettingId, ICreatedModified
       {
        public Guid ThermostatSettingId { get; set; }

        [UiOrder(0, 12)]
        public String Label { get; set; }

        [UiOrder(0, 15)]
        public int Order { get; set; }

        [UiOrder(0, 18)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.TemperatureProvider))]
        public int CoolTemp { get; set; }

        [UiOrder(0, 22)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.TemperatureProvider))]
        public int HeatTemp { get; set; }

        [UiOrder(0, 26)]
        public bool On { get; set; }

        [UiOrder(0, 29)]
        [ValueProvider(typeof(Threax.Home.ValueProviders.ThermostatProvider))]
        public Guid ThermostatId { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
