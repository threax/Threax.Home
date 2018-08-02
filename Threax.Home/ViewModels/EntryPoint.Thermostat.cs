using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.List), "ListThermostats")]
    //[HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Add), "AddThermostat")]
    public partial class EntryPoint
    {
        
    }
}