using Halcyon.HAL.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Controllers;
using Threax.Home.Hue.Models;

namespace Threax.Home.Hue.ViewModels
{
    /// <summary>
    /// View model for switch position.
    /// </summary>
    [HalModel]
    //[HalSelfActionLink(SwitchController.Rels.GetSwitch, typeof(SwitchController))]
    //[HalActionLink(SwitchController.Rels.GetSwitch, typeof(SwitchController))]
    //[HalActionLink(SwitchController.Rels.SetSwitch, typeof(SwitchController))]
    public class HueSwitchPositionView
    {
        /// <summary>
        /// The id of the switch.
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// The value of the switch.
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// The brightness to set.
        /// </summary>
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        public string HexColor { get; set; }

        /// <summary>
        /// The name of the light.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The name of the bridge.
        /// </summary>
        public String Bridge { get; set; }
    }
}
