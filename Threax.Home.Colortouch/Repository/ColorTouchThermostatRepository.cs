using ColorTouchSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Colortouch.Repository
{
    class ColorTouchThermostatRepository<TIn, TOut> : IColorTouchThermostatRepository<TIn, TOut>
        where TIn : IThermostatSetting, new()
        where TOut : IThermostat, new()
    {
        public string SubsystemName => "ColorTouch";

        private IColorTouchClientManager colorTouchManager;

        public ColorTouchThermostatRepository(IColorTouchClientManager colorTouchManager)
        {
            this.colorTouchManager = colorTouchManager;
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var client = colorTouchManager.GetClient(bridge);
            var status = await client.GetStatusAsync();

            return new TOut()
            {
                Subsystem = SubsystemName,
                Bridge = bridge,
                Id = id,
                Name = status.Name,
                Mode = status.Mode,
                State = status.State,
                Fan = status.Fan,
                FanState = status.FanState,
                TempUnits = status.TempUnits,
                Schedule = status.Schedule,
                SchedulePart = status.SchedulePart,
                Away = status.Away,
                Holidy = status.Holidy,
                Override = status.Override,
                OverrideTime = status.OverrideTime,
                ForceUnocc = status.ForceUnocc,
                SpaceTemp = status.SpaceTemp,
                HeatTemp = status.HeatTemp,
                CoolTemp = status.CoolTemp,
                CoolTempMin = status.CoolTempMin,
                CoolTempMax = status.CoolTempMax,
                HeatTempMin = status.HeatTempMin,
                HeatTempMax = status.HeatTempMax,
                SetPointDelta = status.SetPointDelta,
                Humidity = status.Humidity,
                AvailableModes = status.AvailableModes
            };
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var thermostats = new List<TOut>();
            foreach(var client in colorTouchManager.Clients)
            {
                var status = await client.GetStatusAsync();

                thermostats.Add(new TOut()
                {
                    Subsystem = SubsystemName,
                    Bridge = client.Name,
                    Id = "0",
                    Name = status.Name,
                    Mode = status.Mode,
                    State = status.State,
                    Fan = status.Fan,
                    FanState = status.FanState,
                    TempUnits = status.TempUnits,
                    Schedule = status.Schedule,
                    SchedulePart = status.SchedulePart,
                    Away = status.Away,
                    Holidy = status.Holidy,
                    Override = status.Override,
                    OverrideTime = status.OverrideTime,
                    ForceUnocc = status.ForceUnocc,
                    SpaceTemp = status.SpaceTemp,
                    HeatTemp = status.HeatTemp,
                    CoolTemp = status.CoolTemp,
                    CoolTempMin = status.CoolTempMin,
                    CoolTempMax = status.CoolTempMax,
                    HeatTempMin = status.HeatTempMin,
                    HeatTempMax = status.HeatTempMax,
                    SetPointDelta = status.SetPointDelta,
                    Humidity = status.Humidity,
                    AvailableModes = status.AvailableModes
                });
            }

            return thermostats;
        }

        public async Task Set(TIn setting)
        {
            var client = colorTouchManager.GetClient(setting.Bridge);
            var status = await client.ChangeSettingsAsync(new ThermostatSetting()
            {
                Mode = setting.Mode,
                Fan = setting.Fan,
                HeatTemp = setting.HeatTemp,
                CoolTemp = setting.CoolTemp,
            });
        }
    }
}
