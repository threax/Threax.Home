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
using Threax.AspNetCore.Tracking;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ButtonsController), nameof(ButtonsController.Get))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Update))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Delete))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Apply))]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.Get), "GetSwitch")]
    public partial class Button : IButton, IButtonId, ICreatedModified, IHalLinkProvider
    {
        public Guid ButtonId { get; set; }

        [UiOrder(0, 11)]
        public String Label { get; set; }

        [UiOrder(0, 14)]
        public ButtonStateIcon CurrentIcon { get; set; } = ButtonStateIcon.Unknown;

        [UiOrder(0, 15)]
        public int Order { get; set; }

        [UiOrder(0, 18)]
        public ButtonType ButtonType { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

        public List<ButtonState> ButtonStates { get; set; }

        [JsonIgnore]
        public Guid? SwitchId { get => ButtonStates.FirstOrDefault()?.SwitchSettings.FirstOrDefault()?.SwitchId; }

        public void SetCurrentIcon()
        {
            if(ButtonStates == null)
            {
                return;
            }

            //The switch settings has the switch, which has the current value
            var firstState = ButtonStates.FirstOrDefault();
            var currentValue = firstState.SwitchSettings.FirstOrDefault()?.Switch.Value;

            foreach (var state in ButtonStates)
            {
                var switchSettings = state.SwitchSettings.FirstOrDefault();
                if(switchSettings == null)
                {
                    continue;
                }

                if (switchSettings.Value == currentValue)
                {
                    CurrentIcon = state.Icon;
                    return;
                }
            }
        }

        public IEnumerable<HalLinkAttribute> CreateHalLinks(ILinkProviderContext context)
        {
            if(SwitchId != null)
            {
                yield return new HalActionLinkAttribute(typeof(SwitchesController), nameof(SwitchesController.Get), "GetSwitch");
            }
        }
    }
}