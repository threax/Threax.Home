using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.Home.Models;
using Threax.Home.Core;

namespace Threax.Home.Database 
{
    public partial class ThermostatEntity : IThermostat, IThermostatId, IThermostat_State, IThermostat_FanState, IThermostat_TempUnits, IThermostat_Schedule, IThermostat_SchedulePart, IThermostat_Away, IThermostat_Holidy, IThermostat_Override, IThermostat_OverrideTime, IThermostat_ForceUnocc, IThermostat_SpaceTemp, IThermostat_CoolTempMin, IThermostat_CoolTempMax, IThermostat_HeatTempMin, IThermostat_HeatTempMax, IThermostat_SetPointDelta, IThermostat_Humidity, IThermostat_AvailableModes, ICreatedModified
    {
        [Key]
        public Guid ThermostatId { get; set; }

        public String Name { get; set; }

        public String Subsystem { get; set; }

        public String Bridge { get; set; }

        public String Id { get; set; }

        public Mode Mode { get; set; }

        public FanSetting Fan { get; set; }

        public int HeatTemp { get; set; }

        public int CoolTemp { get; set; }

        public State State { get; set; }

        public FanState FanState { get; set; }

        public TempUnits TempUnits { get; set; }

        public SchedulePart Schedule { get; set; }

        public SchedulePart SchedulePart { get; set; }

        public Away Away { get; set; }

        public Holiday Holidy { get; set; }

        public Override Override { get; set; }

        public int OverrideTime { get; set; }

        public ForceUnocc ForceUnocc { get; set; }

        public int SpaceTemp { get; set; }

        public int CoolTempMin { get; set; }

        public int CoolTempMax { get; set; }

        public int HeatTempMin { get; set; }

        public int HeatTempMax { get; set; }

        public int SetPointDelta { get; set; }

        public int Humidity { get; set; }

        public AvailableModes AvailableModes { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
