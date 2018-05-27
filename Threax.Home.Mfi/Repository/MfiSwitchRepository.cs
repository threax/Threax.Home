using MfiSharp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.MFi.Services;

namespace Threax.Home.ZWave.Repository
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class MfiSwitchRepository<TIn, TOut> : IMfiSwitchRepository<TIn, TOut>
       where TIn : ISwitch, new()
       where TOut : ISwitch, new()
    {
        private IPowerStripManager manager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The PowerStripManager to use.</param>
        public MfiSwitchRepository(IPowerStripManager manager)
        {
            this.manager = manager;
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var settings = await manager.GetClient(bridge).GetSettings();
            var intId = int.Parse(id);
            return settings.Where(i => i.Index == intId).Select(i =>
                new TOut()
                {
                    Id = i.Index.ToString(),
                    Value = i.On ? "on" : "off",
                    Subsystem = SubsystemName
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
                        Value = i.On ? "on" : "off",
                        Subsystem = SubsystemName
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

        public String SubsystemName => "Mfi";
    }
}
