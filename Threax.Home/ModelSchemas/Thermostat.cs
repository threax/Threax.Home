using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;
using Threax.Home.Core;

namespace Threax.Home.ModelSchemas
{
    //[RequireAuthorization(typeof(Roles), nameof(Roles.EditValues))]
    [AddNamespaces("using Threax.Home.Core;")]
    public abstract class Thermostat : ICoreThermostat
    {
        [UiOrder]
        public string Name { get; set; }

        [UiOrder]
        public string Subsystem { get; set; }

        [UiOrder]
        public string Bridge { get; set; }

        [UiOrder]
        public string Id { get; set; }

        [UiOrder]
        public Mode Mode { get; set; }

        [UiOrder]
        public FanSetting Fan { get; set; }

        [UiOrder]
        public int HeatTemp { get; set; }

        [UiOrder]
        public int CoolTemp { get; set; }

        [NoInputModel]
        [UiOrder]
        public State State { get; set; }

        [NoInputModel]
        [UiOrder]
        public FanState FanState { get; set; }

        [NoInputModel]
        [UiOrder]
        public TempUnits TempUnits { get; set; }

        [NoInputModel]
        [UiOrder]
        public SchedulePart Schedule { get; set; }

        [NoInputModel]
        [UiOrder]
        public SchedulePart SchedulePart { get; set; }

        [NoInputModel]
        [UiOrder]
        public Away Away { get; set; }

        [NoInputModel]
        [UiOrder]
        public Holiday Holidy { get; set; }

        [NoInputModel]
        [UiOrder]
        public Override Override { get; set; }

        [NoInputModel]
        [UiOrder]
        public int OverrideTime { get; set; }

        [NoInputModel]
        [UiOrder]
        public ForceUnocc ForceUnocc { get; set; }

        [NoInputModel]
        [UiOrder]
        public int SpaceTemp { get; set; }

        [NoInputModel]
        [UiOrder]
        public int CoolTempMin { get; set; }

        [NoInputModel]
        [UiOrder]
        public int CoolTempMax { get; set; }

        [NoInputModel]
        [UiOrder]
        public int HeatTempMin { get; set; }

        [NoInputModel]
        [UiOrder]
        public int HeatTempMax { get; set; }

        [NoInputModel]
        [UiOrder]
        public int SetPointDelta { get; set; }

        [NoInputModel]
        [UiOrder]
        public int Humidity { get; set; }

        [NoInputModel]
        [UiOrder]
        public AvailableModes AvailableModes { get; set; }
    }
}
