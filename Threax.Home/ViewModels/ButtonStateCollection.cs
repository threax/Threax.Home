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
    [HalSelfActionLink(typeof(ButtonsController), nameof(ButtonsController.List))]
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(ButtonsController), nameof(ButtonsController.List), DocsOnly = true)] //This provides docs for searching the list
    [DeclareHalLink(typeof(ButtonsController), nameof(ButtonsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonsController), nameof(ButtonsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonsController), nameof(ButtonsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonsController), nameof(ButtonsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class ButtonStateCollection : PagedCollectionViewWithQuery<ButtonState, ButtonStateQuery>
    {
        public ButtonStateCollection(ButtonStateQuery query, int total, IEnumerable<ButtonState> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ButtonCollection.Generated for the generated code
    }
}