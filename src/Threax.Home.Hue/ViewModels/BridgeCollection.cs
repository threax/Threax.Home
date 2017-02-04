using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Hue.ViewModels
{
    [HalModel]
    public class BridgeCollection : CollectionView<BridgeView>
    {
        public BridgeCollection(IEnumerable<BridgeView> items = null, string name = "values")
            :base(items, name)
        {
        }
    }
}
