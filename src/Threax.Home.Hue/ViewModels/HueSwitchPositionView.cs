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
    //[HalSelfActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    //[HalActionLink(SwitchController.Rels.Set, typeof(SwitchController))]
    public class HueSwitchPositionView : HueSwitchPosition
    {
        /// <summary>
        /// The name of the light.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The name of the bridge.
        /// </summary>
        //[JsonIgnore]
        public String Bridge { get; set; }
    }
}
