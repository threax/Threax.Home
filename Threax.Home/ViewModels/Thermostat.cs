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
using Threax.AspNetCore.Tracking;

namespace Threax.Home.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Get))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Update))]
    [HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.SetTemp))]
    [HalActionLink(typeof(ThermostatSettingsController), nameof(ThermostatSettingsController.GetForThermostat), "GetSettings")]
    //[HalActionLink(typeof(ThermostatsController), nameof(ThermostatsController.Delete))]
    public partial class Thermostat : IThermostat, IThermostatId, IThermostat_State, IThermostat_FanState, IThermostat_TempUnits, IThermostat_Schedule, IThermostat_SchedulePart, IThermostat_Away, IThermostat_Holidy, IThermostat_Override, IThermostat_OverrideTime, IThermostat_ForceUnocc, IThermostat_SpaceTemp, IThermostat_CoolTempMin, IThermostat_CoolTempMax, IThermostat_HeatTempMin, IThermostat_HeatTempMax, IThermostat_SetPointDelta, IThermostat_Humidity, IThermostat_AvailableModes, ICreatedModified, ICoreThermostat
    {
        public Guid ThermostatId { get; set; }

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

        [UiOrder(0, 40)]
        public State State { get; set; }

        [UiOrder(0, 44)]
        public FanState FanState { get; set; }

        [UiOrder(0, 48)]
        public TempUnits TempUnits { get; set; }

        [UiOrder(0, 52)]
        public SchedulePart Schedule { get; set; }

        [UiOrder(0, 56)]
        public SchedulePart SchedulePart { get; set; }

        [UiOrder(0, 60)]
        public Away Away { get; set; }

        [UiOrder(0, 64)]
        public Holiday Holidy { get; set; }

        [UiOrder(0, 68)]
        public Override Override { get; set; }

        [UiOrder(0, 72)]
        public int OverrideTime { get; set; }

        [UiOrder(0, 76)]
        public ForceUnocc ForceUnocc { get; set; }

        [UiOrder(0, 80)]
        public int SpaceTemp { get; set; }

        [UiOrder(0, 84)]
        public int CoolTempMin { get; set; }

        [UiOrder(0, 88)]
        public int CoolTempMax { get; set; }

        [UiOrder(0, 92)]
        public int HeatTempMin { get; set; }

        [UiOrder(0, 96)]
        public int HeatTempMax { get; set; }

        [UiOrder(0, 100)]
        public int SetPointDelta { get; set; }

        [UiOrder(0, 104)]
        public int Humidity { get; set; }

        [UiOrder(0, 108)]
        public AvailableModes AvailableModes { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }
    }
}