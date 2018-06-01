using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    public interface IThermostatSetting
    {
        String Bridge { get; set; }

        String Id { get; set; }

        Mode Mode { get; set; }

        FanSetting Fan { get; set; }

        int HeatTemp { get; set; }

        int CoolTemp { get; set; }

    }

    public interface IThermostat : IThermostatSetting
    {
        String Name { get; set; }

        State State { get; set; }

        FanState FanState { get; set; }

        TempUnits TempUnits { get; set; }

        SchedulePart Schedule { get; set; }

        SchedulePart SchedulePart { get; set; }

        Away Away { get; set; }

        Holiday Holidy { get; set; }

        Override Override { get; set; }

        int OverrideTime { get; set; }

        ForceUnocc ForceUnocc { get; set; }

        int SpaceTemp { get; set; }

        int CoolTempMin { get; set; }

        int CoolTempMax { get; set; }

        int HeatTempMin { get; set; }

        int HeatTempMax { get; set; }

        int SetPointDelta { get; set; }

        int Humidity { get; set; }

        AvailableModes AvailableModes { get; set; }
    }

    public enum Mode
    {
        Off = 0,
        Heat = 1,
        Cool = 2,
        Auto = 3
    }

    public enum State
    {
        Idle = 0,
        Heating = 1,
        Cooling = 2,
        Lockout = 3,
        Error = 4
    }

    public enum FanSetting
    {
        Auto = 0,
        On = 1
    }

    public enum FanState
    {
        Off = 0,
        On = 1
    }

    public enum TempUnits
    {
        Farenheit = 0,
        Celsius = 1
    }

    public enum Schedule
    {
        Farenheit = 0,
        Celsius = 1
    }

    public enum SchedulePart
    {
        Morning = 0,
        Day = 1,
        Evening = 2,
        Night = 3,
        Inactive = 255
    }

    public enum Away
    {
        Home = 0,
        Away = 1
    }

    public enum Holiday
    {
        NotObservingHoliday = 0,
        ObservingHoliday = 1
    }

    public enum Override
    {
        Off = 0,
        On = 1
    }

    public enum ForceUnocc
    {
        Off = 0,
        On = 1
    }

    public enum AvailableModes
    {
        AllModes = 0,
        HeatCoolOnly = 1,
        HeatOnly = 2,
        CoolOnly = 3
    }
}
