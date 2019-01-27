using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Tracking;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Get))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Update))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Delete))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.ApplySetting))]
    public partial class ThermostatSetting : IThermostatSetting, IThermostatSettingId, ICreatedModified
    {
        public Guid ThermostatSettingId { get; set; }

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

        [UiOrder(0, 30)]
        [Display(Name = "Thermostat")]
        [ValueProvider(typeof(Threax.Home.ValueProviders.ThermostatProvider))]
        public Guid ThermostatId { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }
    }
}