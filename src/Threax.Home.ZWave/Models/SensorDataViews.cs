using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.ZWave.Controllers;

namespace Threax.Home.ZWave.ViewModels
{
    [HalModel]
    [HalSelfActionLink(SensorController.Rels.GetTemperature, typeof(SensorController))]
    public class TemperatureDataView : SensorDataView
    {

    }

    [HalModel]
    [HalSelfActionLink(SensorController.Rels.GetHumidity, typeof(SensorController))]
    public class HumidityDataView : SensorDataView
    {

    }

    [HalModel]
    [HalSelfActionLink(SensorController.Rels.GetLight, typeof(SensorController))]
    public class LightDataView : SensorDataView
    {

    }

    [HalModel]
    [HalSelfActionLink(SensorController.Rels.GetUv, typeof(SensorController))]
    public class UvDataView : SensorDataView
    {

    }
}
