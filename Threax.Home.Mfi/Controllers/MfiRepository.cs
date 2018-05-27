using MfiSharp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.MFi.Services;

namespace Threax.Home.ZWave.Controllers
{
    public interface IMfiSwitchRepository<TIn, TOut>
       where TIn : ISwitch, new()
       where TOut : ISwitch, new()
    {
        Task<TOut> Get(string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }

    /// <summary>
    /// Manage switches.
    /// </summary>
    public class MfiRepository<TIn, TOut> : IMfiSwitchRepository<TIn, TOut>
       where TIn : ISwitch, new()
       where TOut : ISwitch, new()
    {
        private IPowerStripManager manager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The PowerStripManager to use.</param>
        public MfiRepository(IPowerStripManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// List all the switches.
        /// </summary>
        /// <param name="strip">The name of the power strip to use.</param>
        /// <returns></returns>
        public async Task<IEnumerable<SwitchInfo<int>>> List(String strip)
        {
            var settings = await manager.GetClient(strip).GetSettings();
            return settings.Select(i => new SwitchInfo<int>()
            {
                Id = i.Index,
                Positions = new List<String>() { "on", "off" },
                DisplayName = $"{strip} Relay {i.Index}"
            });
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var settings = await manager.GetClient(bridge).GetSettings();
            var intId = int.Parse(id);
            return settings.Where(i => i.Index == intId).Select(i =>
                new TOut()
                {
                    Id = i.Index.ToString(),
                    Value = i.On ? "on" : "off"
                }).First();
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var clients = new List<TOut>();
            foreach (var bridge in this.manager.ClientNames)
            {
                var settings = await manager.GetClient(bridge).GetSettings();
                clients.AddRange(settings.Select(i =>
                    new TOut()
                    {
                        Id = i.Index.ToString(),
                        Value = i.On ? "on" : "off"
                    }));
            }
            return clients;
        }

        public async Task Set(TIn setting)
        {
            await manager.GetClient(setting.Bridge).ApplySettings(new RelaySetting[]
            {
                new RelaySetting(int.Parse(setting.Id), setting.Value == "on")
            });
        }
    }
}
