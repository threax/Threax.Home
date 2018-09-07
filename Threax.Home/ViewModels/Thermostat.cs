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
using Threax.Home.Core;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Get))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Update))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.SetTemp))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.GetForThermostat), "GetSettings")]
    //[HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Delete))]
    public partial class Thermostat : ICoreThermostat
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Thermostat.Generated for the generated code
    }
}