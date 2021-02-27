using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Client.Repository
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class ClientThermostatRepository<TIn, TOut> : IClientThermostatRepository<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        private readonly IHomeClientManager clientManager;
        private readonly ILogger<ClientThermostatRepository<TIn, TOut>> logger;

        public string SubsystemName => "HomeClient";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        /// <param name="config">The config</param>
        public ClientThermostatRepository(IHomeClientManager clientManager, ILogger<ClientThermostatRepository<TIn, TOut>> logger)
        {
            this.clientManager = clientManager;
            this.logger = logger;
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var thermostat = await clientManager.GetClient(bridge).GetThermostat(id);

            return new TOut()
            {
                Id = thermostat.Data.ThermostatId.ToString(),
                Name = thermostat.Data.Name,
                Bridge = bridge,
                Subsystem = SubsystemName,
                HeatTemp = thermostat.Data.HeatTemp,
                CoolTemp = thermostat.Data.CoolTemp,
                Mode = (Core.Mode)thermostat.Data.Mode,
                Fan = (Core.FanSetting)thermostat.Data.Fan,
                State = (Core.State)thermostat.Data.State,
                FanState = (Core.FanState)thermostat.Data.FanState,
                SpaceTemp = thermostat.Data.SpaceTemp,
                Humidity = thermostat.Data.Humidity
            };
        }

        public async Task Set(TIn setting)
        {
            var input = new ThermostatInput()
            {
                Bridge = setting.Bridge,
                CoolTemp = setting.CoolTemp,
                Fan = (FanSetting)setting.Fan,
                HeatTemp = setting.HeatTemp,
                Id = setting.Id,
                Mode = (Mode)setting.Mode,
                Subsystem = setting.Subsystem,
            };

            var thermostat = await clientManager.GetClient(setting.Bridge).GetThermostat(setting.Id);

            await thermostat.Update(input);
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var switches = new List<TOut>();
            foreach (var bridge in clientManager.GetClientNames())
            {
                try
                {
                    var thermoInfo = await clientManager.GetClient(bridge).GetThermostats();
                    var tasks = thermoInfo.Select(async info =>
                    {
                        try
                        {
                            var thermostat = await clientManager.GetClient(bridge).GetThermostat(info.Data.ThermostatId.ToString());
                            return new TOut()
                            {
                                Id = thermostat.Data.ThermostatId.ToString(),
                                Name = $"{bridge} - {thermostat.Data.Name}",
                                Bridge = bridge,
                                Subsystem = SubsystemName,
                                HeatTemp = thermostat.Data.HeatTemp,
                                CoolTemp = thermostat.Data.CoolTemp,
                                Mode = (Core.Mode)thermostat.Data.Mode,
                                Fan = (Core.FanSetting)thermostat.Data.Fan,
                                State = (Core.State)thermostat.Data.State,
                                FanState = (Core.FanState)thermostat.Data.FanState,
                                SpaceTemp = thermostat.Data.SpaceTemp,
                                Humidity = thermostat.Data.Humidity
                            };
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, $"'{ex.GetType().FullName}' occured with the loading thermostats. The switch '{info.Data.Name}' id: '{info.Data.ThermostatId}' was skipped.{Environment.NewLine}Full Exception:");

                            return new TOut()
                            {
                                Id = info.Data.ThermostatId.ToString(),
                                Name = $"{bridge} - {info.Data.Name}",
                                Bridge = bridge,
                                Subsystem = SubsystemName
                            };
                        }
                    });
                    foreach (var task in tasks)
                    {
                        switches.Add(await task);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"'{ex.GetType().FullName}' occured with the loading switches. The bridge '{bridge}' was skipped.{Environment.NewLine}Full Exception:");
                }
            }

            return switches.ToList();
        }
    }
}
