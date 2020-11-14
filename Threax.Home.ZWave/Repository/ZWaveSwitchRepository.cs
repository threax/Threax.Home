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

        public async Task<TOut> Get(string bridge, string id)
        {
            var byteId = byte.Parse(id);
            //Hardcoded, for now
            switch (byteId)
            {
                case 2:
                    return await GetSwitch3Switch(bridge, 2);
                case 4:
                    return await GetSwitch2Switch(bridge, 4);
                default:
                    throw new FileNotFoundException();
            }
        }

        public async Task Set(TIn setting)
        {
            switch (int.Parse(setting.Id))
            {
                case 2:
                    await SetSwitch3Switch(setting);
                    break;
                case 4:
                    await SetSwitch2Switch(setting);
                    break;
                default:
                    throw new FileNotFoundException();
            }
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var switches = new List<TOut>();

            foreach(var node in await zwave.GetNodes())
            {
                var protocolInfo = await node.GetProtocolInfo();
                switch (protocolInfo.GenericType)
                {
                    case GenericType.SwitchMultiLevel:
                    case GenericType.SwitchBinary:
                        switches.Add(new TOut()
                        {
                            Id = node.NodeID.ToString(),
                            Value = "",
                            Bridge = config.ComPort,
                            Subsystem = SubsystemName,
                            Name = $"{SubsystemName} Node {node.NodeID}"
                        });
                        break;
                }
            }

            return switches;
        }

        private async Task<Basic> GetBasicCommand(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId).GetCommandClass<Basic>();
        }

        private async Task SetSwitch3Switch(TIn setting)
        {
            var byteId = byte.Parse(setting.Id);
            var com = await GetBasicCommand(byteId);
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

        private async Task<TOut> GetSwitch3Switch(String bridge, byte id)
        {
            var com = await GetBasicCommand(id);
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
                Id = id.ToString(),
                Value = value.ToString(),
                Bridge = bridge,
                Subsystem = SubsystemName,
                Name = $"{SubsystemName} Node {com.Node.NodeID}"
            };
        }

        private async Task SetSwitch2Switch(TIn setting)
        {
            var byteId = byte.Parse(setting.Id);
            var com = await GetBasicCommand(byteId);
            switch (Enum.Parse(typeof(Switch2SwitchPosition), setting.Value))
            {
                case Switch2SwitchPosition.off:
                    await com.Set(0);
                    break;
                case Switch2SwitchPosition.on:
                    await com.Set(255);
                    break;
                default:
                    throw new ErrorResultException($"{setting.Value} is not a valid position for {setting.Id}");
            }
        }

        private async Task<TOut> GetSwitch2Switch(String bridge, byte id)
        {
            var com = await GetBasicCommand(id);
            var b = (await com.Get()).Value;
            var value = Switch2SwitchPosition.off;
            if (b == 0)
            {
                value = Switch2SwitchPosition.off;
            }
            else if (b > 0)
            {
                value = Switch2SwitchPosition.on;
            }

            return new TOut()
            {
                Id = id.ToString(),
                Value = value.ToString(),
                Bridge = bridge,
                Subsystem = SubsystemName,
                Name = $"{SubsystemName} Node {com.Node.NodeID}"
            };
        }
    }
}
