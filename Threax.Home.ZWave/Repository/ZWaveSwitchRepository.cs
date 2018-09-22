using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.ExceptionFilter;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.ZWave.Models;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Repository
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class ZWaveSwitchRepository<TIn, TOut> : IZWaveSwitchRepository<TIn, TOut>
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        private ZWaveController zwave;
        private ZWaveConfig config;

        public string SubsystemName => "ZWave";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        /// <param name="config">The config</param>
        public ZWaveSwitchRepository(IZWaveControllerAccessor zwave, ZWaveConfig config)
        {
            this.zwave = zwave.Controller;
            this.config = config;
        }

        private async Task<Basic> GetBasicCommand(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId).GetCommandClass<Basic>();
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var intId = int.Parse(id);
            //Hardcoded, for now
            Basic com;
            switch (intId)
            {
                case 2:
                    com = await GetBasicCommand(2);
                    break;
                default:
                    throw new FileNotFoundException();
            }

            var b = (await com.Get()).Value;
            Switch3SwitchPosition value = Switch3SwitchPosition.off;
            if (b == 0)
            {
                value = Switch3SwitchPosition.off;
            }
            else if (b < 10)
            {
                value = Switch3SwitchPosition.low;
            }
            else if (b < 60)
            {
                value = Switch3SwitchPosition.medium;
            }
            else if (b < 100)
            {
                value = Switch3SwitchPosition.high;
            }
            return new TOut()
            {
                Id = intId.ToString(),
                Value = value.ToString(),
                Bridge = bridge,
                Subsystem = SubsystemName,
                Name = "Bedroom Fan"
            };
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var switches = new List<TOut>();

            switches.Add(await Get(config.ComPort, "2"));

            return switches;
        }

        public async Task Set(TIn setting)
        {
            Basic com;
            switch (int.Parse(setting.Id))
            {
                case 2:
                    com = await GetBasicCommand(2);
                    break;
                default:
                    throw new FileNotFoundException();
            }

            switch (Enum.Parse(typeof(Switch3SwitchPosition), setting.Value))
            {
                case Switch3SwitchPosition.off:
                    await com.Set(0);
                    break;
                case Switch3SwitchPosition.low:
                    await com.Set(1);
                    break;
                case Switch3SwitchPosition.medium:
                    await com.Set(50);
                    break;
                case Switch3SwitchPosition.high:
                    await com.Set(99);
                    break;
                default:
                    throw new ErrorResultException($"{setting.Value} is not a valid position for {setting.Id}");
            }
        }
    }
}
