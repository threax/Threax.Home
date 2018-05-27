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
    //[HalSelfActionLink(typeof(BridgeController), nameof(BridgeController.Get))]
    //[HalActionLink(typeof(BridgeController), nameof(BridgeController.Get), DocsOnly = true)] //This provides access to docs for showing items
    //[HalActionLink(typeof(BridgeController), nameof(BridgeController.List), DocsOnly = true)] //This provides docs for searching the list
    //[HalActionLink(typeof(BridgeController), nameof(BridgeController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    //[HalActionLink(typeof(BridgeController), nameof(BridgeController.Add))]
    //[DeclareHalLink(typeof(BridgeController), nameof(BridgeController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    //[DeclareHalLink(typeof(BridgeController), nameof(BridgeController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    //[DeclareHalLink(typeof(BridgeController), nameof(BridgeController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    //[DeclareHalLink(typeof(BridgeController), nameof(BridgeController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public class BridgeCollection : CollectionView<BridgeView>
    {
        public BridgeCollection(IEnumerable<BridgeView> items) : base(items)
        {
        }
    }
}
