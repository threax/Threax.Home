using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Models;
using Threax.Home.Controllers.Api;
using Threax.Home.Core;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(SensorsController), nameof(SensorsController.Get))]
    [HalActionLink(typeof(SensorsController), nameof(SensorsController.Update))]
    //[HalActionLink(typeof(SensorsController), nameof(SensorsController.Delete))]
    public partial class Sensor
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Sensor.Generated for the generated code
    }
}