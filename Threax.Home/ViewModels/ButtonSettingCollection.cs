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
    [HalSelfActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List))]
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.Add))]
    [DeclareHalLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(ButtonSettingsController), nameof(ButtonSettingsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class ButtonSettingCollection
    {
        public ButtonSettingCollection(ButtonSettingQuery query, int total, IEnumerable<ButtonSetting> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See ButtonSettingCollection.Generated for the generated code
    }
}