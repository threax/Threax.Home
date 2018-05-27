using System.Collections.Generic;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Hue.ViewModels
{
    public class BridgeCollection : CollectionView<BridgeView>
    {
        public BridgeCollection(IEnumerable<BridgeView> items) : base(items)
        {
        }
    }
}
