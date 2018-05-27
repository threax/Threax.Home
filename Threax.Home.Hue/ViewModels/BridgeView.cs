using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Controllers;

namespace Threax.Home.Hue.ViewModels
{
    [HalModel]
    //[HalSelfActionLink(BridgeController.Rels.ListBridges, typeof(BridgeController))]
    //[HalActionLink(SwitchController.Rels.ListSwitches, typeof(SwitchController))]
    public class BridgeView
    {
        public String Bridge { get; set; }
    }
}
