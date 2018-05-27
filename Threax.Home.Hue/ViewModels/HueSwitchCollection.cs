using System;
using System.Collections.Generic;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Hue.ViewModels
{
    public class HueSwitchCollection : CollectionView<HueSwitchPositionView>
    {
        public HueSwitchCollection(IEnumerable<HueSwitchPositionView> items, String bridge)
            :base(items)
        {
            Bridge = bridge;
        }

        public string Bridge { get; set; }
    }
}
