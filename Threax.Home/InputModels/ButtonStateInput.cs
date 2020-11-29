using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class ButtonStateInput : IButtonState
    {
        [UiOrder(0, 15)]
        public String Label { get; set; }

        [UiOrder(0, 16)]
        public ButtonStateIcon Icon { get; set; }

        [UiOrder(0, 18)]
        public int Order { get; set; }

        public List<SwitchSettingInput> SwitchSettings { get; set; }
    }
}