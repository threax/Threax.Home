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
    [HalSelfActionLink(typeof(AppCommandsController), nameof(AppCommandsController.List))]
    [HalActionLink(typeof(AppCommandsController), nameof(AppCommandsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(AppCommandsController), nameof(AppCommandsController.List), DocsOnly = true)] //This provides docs for searching the list
    [DeclareHalLink(typeof(AppCommandsController), nameof(AppCommandsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandsController), nameof(AppCommandsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandsController), nameof(AppCommandsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(AppCommandsController), nameof(AppCommandsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class AppCommandCollection : PagedCollectionViewWithQuery<AppCommand, AppCommandQuery>
    {
        public AppCommandCollection(AppCommandQuery query, int total, IEnumerable<AppCommand> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ButtonCollection.Generated for the generated code
    }
}