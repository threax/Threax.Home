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
    [HalActionLink(SensorController.Rels.GetHumidity, typeof(SensorController))]
    [HalActionLink(SensorController.Rels.GetLight, typeof(SensorController))]
    [HalActionLink(SensorController.Rels.GetTemperature, typeof(SensorController))]
    [HalActionLink(SensorController.Rels.GetUv, typeof(SensorController))]
    public class SensorInfoView
    {
        public byte Id { get; set; }
    }
}
