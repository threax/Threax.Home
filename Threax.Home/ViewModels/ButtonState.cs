using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Controllers.Api;
using Threax.Home.Models;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ButtonStatesController), nameof(ButtonStatesController.Get))]
    [HalActionLink(typeof(ButtonStatesController), nameof(ButtonStatesController.Apply))]
    public partial class ButtonState : IButtonState, IButtonStateId
    {
        public Guid ButtonStateId { get; set; }

        [UiOrder(0, 15)]
        public String Label { get; set; }

        [UiOrder(0, 16)]
        public ButtonStateIcon Icon { get; set; }

        [UiOrder(0, 18)]
        public int Order { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

        public List<SwitchSetting> SwitchSettings { get; set; }
    }
}