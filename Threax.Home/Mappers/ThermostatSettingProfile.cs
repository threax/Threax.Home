using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Models;
using Threax.Home.InputModels;
using Threax.Home.Database;
using Threax.Home.ViewModels;

namespace Threax.Home.Mappers
{
    public partial class AppMapper
    {
        public ThermostatSettingEntity MapThermostatSetting(ThermostatSettingInput src, ThermostatSettingEntity dest)
        {
            //dest.ThermostatSettingId ignored
            dest.Label = src.Label;
            dest.Order = src.Order;
            dest.CoolTemp = src.CoolTemp;
            dest.HeatTemp = src.HeatTemp;
            dest.On = src.On;
            dest.ThermostatId = src.ThermostatId;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public ThermostatSetting MapThermostatSetting(ThermostatSettingEntity src, ThermostatSetting dest)
        {
            dest.ThermostatSettingId = src.ThermostatSettingId;
            dest.Label = src.Label;
            dest.Order = src.Order;
            dest.CoolTemp = src.CoolTemp;
            dest.HeatTemp = src.HeatTemp;
            dest.On = src.On;
            dest.ThermostatId = src.ThermostatId;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}