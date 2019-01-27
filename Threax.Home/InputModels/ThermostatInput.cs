using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Core;
using Threax.Home.Models;

namespace Threax.Home.InputModels
{
    [HalModel]
    public partial class ThermostatInput : IThermostat, ICoreThermostatSetting
    {
        [UiOrder(0, 15)]
        public String Name { get; set; }

        [UiOrder(0, 18)]
        public String Subsystem { get; set; }

        [UiOrder(0, 21)]
        public String Bridge { get; set; }

        [UiOrder(0, 24)]
        public String Id { get; set; }

        [UiOrder(0, 27)]
        public Mode Mode { get; set; }

        [UiOrder(0, 30)]
        public FanSetting Fan { get; set; }

        [UiOrder(0, 33)]
        public int HeatTemp { get; set; }

        [UiOrder(0, 36)]
        public int CoolTemp { get; set; }
    }
}