using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.WinLirc.Services;

namespace Threax.Home.WinLirc.Repository
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class WinLircSwitchRepository<TIn, TOut> : IWinLircSwitchRepository<TIn, TOut>
       where TIn : ICoreSwitch, new()
       where TOut : ICoreSwitch, new()
    {
        private IWinLircManager manager;
        private WinLircConfig config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The PowerStripManager to use.</param>
        public WinLircSwitchRepository(IWinLircManager manager, WinLircConfig config)
        {
            this.manager = manager;
            this.config = config;
        }

        public Task<TOut> Get(string bridge, string id)
        {
            if (config.Devices.ContainsKey(id))
            {
                return Task.FromResult(new TOut()
                {
                    Id = id,
                    Value = "",
                    Subsystem = SubsystemName,
                    Bridge = bridge,
                    Name = id
                });
            }
            throw new KeyNotFoundException($"{id} not found");
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var clients = new List<TOut>(config.Devices.Keys.Select(i =>
                new TOut()
                {
                    Id = i,
                    Value = "",
                    Subsystem = SubsystemName,
                    Bridge = "main",
                    Name = i
                }));
            return await Task.FromResult(clients);
        }

        public async Task Set(TIn setting)
        {
            List<String> device;
            if (!config.Devices.TryGetValue(setting.Id, out device))
            {
                throw new KeyNotFoundException($"{setting.Id} not found.");
            }
            if (!device.Contains(setting.Value))
            {
                throw new KeyNotFoundException($"{setting.Id} no command '{setting.Value}'.");
            }

            await this.manager.PushButton(setting.Id, setting.Value);
        }

        public String SubsystemName => "WinLirc";
    }
}
