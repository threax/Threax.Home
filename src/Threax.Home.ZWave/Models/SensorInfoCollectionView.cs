using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ZWave.Controllers;

namespace Threax.Home.ZWave.Models
{
    [HalModel]
    [HalSelfLink]
    [HalActionLink(SensorController.Rels.ListSensors, typeof(SensorController))]
    public class SensorInfoCollectionView : CollectionView<SensorInfoView>
    {
        public SensorInfoCollectionView(IEnumerable<SensorInfoView> items = null)
            :base(items, "values")
        {
        }
    }
}
