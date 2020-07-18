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
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.Add))]
    [DeclareHalLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class ThermostatSettingCollection : PagedCollectionViewWithQuery<ThermostatSetting, ThermostatSettingQuery>
    {
        public ThermostatSettingCollection(ThermostatSettingQuery query, int total, IEnumerable<ThermostatSetting> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ThermostatSettingCollection.Generated for the generated code
    }
}