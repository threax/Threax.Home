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
    [HalSelfActionLink(EntryPointController.Rels.Get, typeof(EntryPointController))]
    [HalActionLink(SensorController.Rels.ListSensors, typeof(SensorController))]
    [HalActionLink(SwitchController.Rels.List, typeof(SwitchController))]
    public class EntryPointView
    {
    }
}
