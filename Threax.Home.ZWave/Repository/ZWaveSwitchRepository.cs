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
            var com = await GetBasicCommand(byteId);
            var value = (await com.Get()).Value;

            return new TOut()
            {
                Id = id,
                Value = value.ToString(),
                Bridge = bridge,
                Subsystem = SubsystemName,
                Name = $"{SubsystemName} Node {com.Node.NodeID}"
            };
        }

        public async Task Set(TIn setting)
        {
            var byteId = byte.Parse(setting.Id);
            var com = await GetBasicCommand(byteId);
            var value = byte.Parse(setting.Value);
            await com.Set(value);
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
    }
}
