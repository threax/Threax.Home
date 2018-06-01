using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace ColorTouchSharp
{
    public class ThermostatStatus
    {
        [JsonProperty("name")]//: "Office",
        public String Name { get; set; }

        [JsonProperty("mode")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        [JsonProperty("state")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public State State { get; set; }

        [JsonProperty("fan")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public FanSetting Fan { get; set; }

        [JsonProperty("fanstate")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public FanState FanState { get; set; }

        [JsonProperty("tempunits")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public TempUnits TempUnits { get; set; }

        [JsonProperty("schedule")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public SchedulePart Schedule { get; set; }

        [JsonProperty("schedulepart")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public SchedulePart SchedulePart { get; set; }

        [JsonProperty("away")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public Away Away { get; set; }

        [JsonProperty("holiday")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public Holiday Holidy { get; set; }

        [JsonProperty("override")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public Override Override { get; set; }

        [JsonProperty("overridetime")]//: 0,
        public int OverrideTime { get; set; }

        [JsonProperty("forceunocc")]//: 0,
        [JsonConverter(typeof(StringEnumConverter))]
        public ForceUnocc ForceUnocc { get; set; }

        [JsonProperty("spacetemp")]//: 79,
        public int SpaceTemp { get; set; }

        [JsonProperty("heattemp")]//: 78,
        public int HeatTemp { get; set; }

        [JsonProperty("cooltemp")]//: 75,
        public int CoolTemp { get; set; }

        [JsonProperty("cooltempmin")]//: 35,
        public int CoolTempMin { get; set; }

        [JsonProperty("cooltempmax")]//: 99,
        public int CoolTempMax { get; set; }

        [JsonProperty("heattempmin")]//: 35,
        public int HeatTempMin { get; set; }

        [JsonProperty("heattempmax")]//: 99,
        public int HeatTempMax { get; set; }

        [JsonProperty("setpointdelta")]//: 2,
        public int SetPointDelta { get; set; }

        [JsonProperty("hum")]//: 2,
        public int Humidity { get; set; }

        [JsonProperty("availablemodes")]//: 0
        [JsonConverter(typeof(StringEnumConverter))]
        public AvailableModes AvailableModes { get; set; }

        //"name": "Office",
        //"mode": 0,
        //"state": 0,
        //"fan": 0,
        //"fanstate": 0,
        //"tempunits": 0,
        //"schedule": 0,
        //"schedulepart": 0,
        //"away": 0,
        //"holiday": 0,
        //"override": 0,
        //"overridetime": 0,
        //"forceunocc": 0,
        //"spacetemp": 79,
        //"heattemp": 78,
        //"cooltemp": 75,
        //"cooltempmin": 35,
        //"cooltempmax": 99,
        //"heattempmin": 35,
        //"heattempmax": 99,
        //"setpointdelta": 2,
        //"availablemodes": 0
    }
}
