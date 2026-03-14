using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Models;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;
using Threax.Home.Core;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public ThermostatEntity MapThermostat(ThermostatInput src, ThermostatEntity dest)
        {
            //dest.ThermostatId ignored
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.Mode = src.Mode;
            dest.Fan = src.Fan;
            dest.HeatTemp = src.HeatTemp;
            dest.CoolTemp = src.CoolTemp;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public Thermostat MapThermostat(ThermostatEntity src, Thermostat dest)
        {
            dest.ThermostatId = src.ThermostatId;
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.Mode = src.Mode;
            dest.Fan = src.Fan;
            dest.HeatTemp = src.HeatTemp;
            dest.CoolTemp = src.CoolTemp;
            dest.State = src.State;
            dest.FanState = src.FanState;
            dest.TempUnits = src.TempUnits;
            dest.Schedule = src.Schedule;
            dest.SchedulePart = src.SchedulePart;
            dest.Away = src.Away;
            dest.Holidy = src.Holidy;
            dest.Override = src.Override;
            dest.OverrideTime = src.OverrideTime;
            dest.ForceUnocc = src.ForceUnocc;
            dest.SpaceTemp = src.SpaceTemp;
            dest.CoolTempMin = src.CoolTempMin;
            dest.CoolTempMax = src.CoolTempMax;
            dest.HeatTempMin = src.HeatTempMin;
            dest.HeatTempMax = src.HeatTempMax;
            dest.SetPointDelta = src.SetPointDelta;
            dest.Humidity = src.Humidity;
            dest.AvailableModes = src.AvailableModes;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }

        public ThermostatEntity MapThermostat(Thermostat src, ThermostatEntity dest)
        {
            dest.ThermostatId = src.ThermostatId;
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.Mode = src.Mode;
            dest.Fan = src.Fan;
            dest.HeatTemp = src.HeatTemp;
            dest.CoolTemp = src.CoolTemp;
            dest.State = src.State;
            dest.FanState = src.FanState;
            dest.TempUnits = src.TempUnits;
            dest.Schedule = src.Schedule;
            dest.SchedulePart = src.SchedulePart;
            dest.Away = src.Away;
            dest.Holidy = src.Holidy;
            dest.Override = src.Override;
            dest.OverrideTime = src.OverrideTime;
            dest.ForceUnocc = src.ForceUnocc;
            dest.SpaceTemp = src.SpaceTemp;
            dest.CoolTempMin = src.CoolTempMin;
            dest.CoolTempMax = src.CoolTempMax;
            dest.HeatTempMin = src.HeatTempMin;
            dest.HeatTempMax = src.HeatTempMax;
            dest.SetPointDelta = src.SetPointDelta;
            dest.Humidity = src.Humidity;
            dest.AvailableModes = src.AvailableModes;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }

        public ThermostatInput MapThermostat(Thermostat src, ThermostatInput dest)
        {
            dest.Name = src.Name;
            dest.Subsystem = src.Subsystem;
            dest.Bridge = src.Bridge;
            dest.Id = src.Id;
            dest.Mode = src.Mode;
            dest.Fan = src.Fan;
            dest.HeatTemp = src.HeatTemp;
            dest.CoolTemp = src.CoolTemp;

            return dest;
        }
    }
}