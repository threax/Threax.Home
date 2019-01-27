using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Threax.Home.Models
{
    public partial interface IThermostatSetting
    {
        String Label { get; set; }

        int Order { get; set; }

        int CoolTemp { get; set; }

        int HeatTemp { get; set; }

        bool On { get; set; }

        Guid ThermostatId { get; set; }

    }

    public partial interface IThermostatSettingId
    {
        Guid ThermostatSettingId { get; set; }
    }

    public partial interface IThermostatSettingQuery
    {
        Guid? ThermostatSettingId { get; set; }
        Guid? ThermostatId { get; set; }


    }
}