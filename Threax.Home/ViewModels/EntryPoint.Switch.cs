using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.List), "ListSwitches")]
    //[HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Add), "AddSwitch")]
    public partial class EntryPoint
    {
        
    }
}