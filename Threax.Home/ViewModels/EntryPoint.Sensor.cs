using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.List), "ListSensors")]
    //[HalActionLink(typeof(SensorsController), nameof(SensorsController.Add), "AddSensor")]
    public partial class EntryPoint
    {
        
    }
}