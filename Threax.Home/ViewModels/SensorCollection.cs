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
    [HalSelfActionLink(typeof(SensorsController), nameof(SensorsController.List))]
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.Add))]
    [DeclareHalLink(typeof(SensorsController), nameof(SensorsController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(SensorsController), nameof(SensorsController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(SensorsController), nameof(SensorsController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(SensorsController), nameof(SensorsController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class SensorCollection
    {
        public SensorCollection(SensorQuery query, int total, IEnumerable<Sensor> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See SensorCollection.Generated for the generated code
    }
}