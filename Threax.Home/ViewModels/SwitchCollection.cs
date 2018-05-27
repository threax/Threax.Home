using Halcyon.HAL.Attributes;
using Threax.Home.Controllers.Api;
using Threax.Home.Models;
using Threax.Home.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(SwitchesController), nameof(SwitchesController.List))]
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    //[HalActionLink(typeof(SwitchesController), nameof(SwitchesController.Add))]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(SwitchesController), nameof(SwitchesController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class SwitchCollection
    {
        public SwitchCollection(SwitchQuery query, int total, IEnumerable<Switch> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See SwitchCollection.Generated for the generated code
    }
}