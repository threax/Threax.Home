using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), "ListThermostatSettings")]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Add), "AddThermostatSetting")]
    public partial class EntryPoint
    {
        
    }
}