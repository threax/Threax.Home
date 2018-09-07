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

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Get))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Update))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Delete))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.ApplySetting))]
    public partial class ThermostatSetting
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ThermostatSetting.Generated for the generated code
    }
}