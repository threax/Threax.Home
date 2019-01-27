using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.Home.Core;

namespace Threax.Home.Models
{
    public partial interface IThermostat
    {
        String Name { get; set; }

        String Subsystem { get; set; }

        String Bridge { get; set; }

        String Id { get; set; }

        Mode Mode { get; set; }

        FanSetting Fan { get; set; }

        int HeatTemp { get; set; }

        int CoolTemp { get; set; }

    }

    public partial interface IThermostat_State
    {
        State State { get; set; }

    }

    public partial interface IThermostat_FanState
    {
        FanState FanState { get; set; }

    }

    public partial interface IThermostat_TempUnits
    {
        TempUnits TempUnits { get; set; }

    }

    public partial interface IThermostat_Schedule
    {
        SchedulePart Schedule { get; set; }

    }

    public partial interface IThermostat_SchedulePart
    {
        SchedulePart SchedulePart { get; set; }

    }

    public partial interface IThermostat_Away
    {
        Away Away { get; set; }

    }

    public partial interface IThermostat_Holidy
    {
        Holiday Holidy { get; set; }

    }

    public partial interface IThermostat_Override
    {
        Override Override { get; set; }

    }

    public partial interface IThermostat_OverrideTime
    {
        int OverrideTime { get; set; }

    }

    public partial interface IThermostat_ForceUnocc
    {
        ForceUnocc ForceUnocc { get; set; }

    }

    public partial interface IThermostat_SpaceTemp
    {
        int SpaceTemp { get; set; }

    }

    public partial interface IThermostat_CoolTempMin
    {
        int CoolTempMin { get; set; }

    }

    public partial interface IThermostat_CoolTempMax
    {
        int CoolTempMax { get; set; }

    }

    public partial interface IThermostat_HeatTempMin
    {
        int HeatTempMin { get; set; }

    }

    public partial interface IThermostat_HeatTempMax
    {
        int HeatTempMax { get; set; }

    }

    public partial interface IThermostat_SetPointDelta
    {
        int SetPointDelta { get; set; }

    }

    public partial interface IThermostat_Humidity
    {
        int Humidity { get; set; }

    }

    public partial interface IThermostat_AvailableModes
    {
        AvailableModes AvailableModes { get; set; }

    }

    public partial interface IThermostatId
    {
        Guid ThermostatId { get; set; }
    }

    public partial interface IThermostatQuery
    {
        Guid? ThermostatId { get; set; }

    }
}