using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Controllers;
using Threax.Home.Hue.Models;

namespace Threax.Home.Hue.ViewModels
{
    [HalModel]
    [HalSelfActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    [HalActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    public class HueSwitchPositions : CollectionView<HueSwitchPosition>
    {
        public HueSwitchPositions(IEnumerable<HueSwitchPosition> items, String bridge)
        {
            this.Items = items;
            Bridge = bridge;
        }

        public string Bridge { get; set; }
    }
}
