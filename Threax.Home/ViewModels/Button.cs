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
using Newtonsoft.Json;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ButtonsController), nameof(ButtonsController.Get))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Update))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Delete))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Apply))]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.Get), "GetSwitch")]
    public partial class Button : IHalLinkProvider
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Button.Generated for the generated code

        public List<ButtonState> ButtonStates { get; set; }

        [JsonIgnore]
        public Guid? SwitchId { get => ButtonStates.FirstOrDefault()?.SwitchSettings.FirstOrDefault()?.SwitchId; }

        public IEnumerable<HalLinkAttribute> CreateHalLinks(ILinkProviderContext context)
        {
            if(SwitchId != null)
            {
                yield return new HalActionLinkAttribute(typeof(SwitchesController), nameof(SwitchesController.Get), "GetSwitch");
            }
        }
    }
}