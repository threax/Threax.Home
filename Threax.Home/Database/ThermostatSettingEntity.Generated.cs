using System;
using System.ComponentModel.DataAnnotations;
using Threax.Home.Models;

namespace Threax.Home.Database 
{
    public partial class ThermostatSettingEntity : IThermostatSetting, IThermostatSettingId
    {
        [Key]
        public Guid ThermostatSettingId { get; set; }

        public String Label { get; set; }

        public int Order { get; set; }

        public int CoolTemp { get; set; }

        public int HeatTemp { get; set; }

        public bool On { get; set; }

        public Guid ThermostatId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
