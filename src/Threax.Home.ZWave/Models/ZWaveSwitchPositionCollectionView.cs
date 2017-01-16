using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.ZWave.Models
{
    [HalModel]
    [HalSelfLink]
    public class ZWaveSwitchPositionCollectionView : CollectionView<ZWaveSwitchPosition>
    {
        public ZWaveSwitchPositionCollectionView(IEnumerable<ZWaveSwitchPosition> items = null, string name = "values") : base(items, name)
        {
        }
    }
}
