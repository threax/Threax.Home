using Halcyon.HAL.Attributes;
using Threax.Home.Controllers.Api;
using Threax.Home.Models;
using Threax.Home.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(ThermostatsController), nameof(ThermostatsController.List))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    //[HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Add))]
    [DeclareHalLink(typeof(ThermostatsController), nameof(ThermostatsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatsController), nameof(ThermostatsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatsController), nameof(ThermostatsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatsController), nameof(ThermostatsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class ThermostatCollection : PagedCollectionViewWithQuery<Thermostat, ThermostatQuery>
    {
        public ThermostatCollection(ThermostatQuery query, int total, IEnumerable<Thermostat> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ThermostatCollection.Generated for the generated code
    }
}