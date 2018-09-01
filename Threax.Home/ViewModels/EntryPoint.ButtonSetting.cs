using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), "ListButtonSettings")]
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Add), "AddButtonSetting")]
    public partial class EntryPoint
    {
        
    }
}