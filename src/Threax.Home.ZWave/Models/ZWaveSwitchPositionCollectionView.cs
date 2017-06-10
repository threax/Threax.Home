using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ZWave.Controllers;

namespace Threax.Home.ZWave.Models
{
    [HalModel]
    [HalSelfActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    [HalActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    public class ZWaveSwitchPositionCollectionView : CollectionView<ZWaveSwitchPosition>
    {
        public ZWaveSwitchPositionCollectionView(IEnumerable<ZWaveSwitchPosition> items = null) : base(items)
        {
        }
    }
}
