using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Controllers.Api;

namespace Threax.Home.ViewModels
{
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.List), "ListButtons")]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Add), "AddButton")]
    public partial class EntryPoint
    {
        
    }
}