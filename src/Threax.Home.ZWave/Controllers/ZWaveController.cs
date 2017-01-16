using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.ZWave.Models;
using ZWave;
using ZWave.Channel;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]/[action]")]
    public class ZWaveConfigController : Controller
    {
        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public ZWaveConfigController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet("{Id}")]
        public async Task<IEnumerable<CommandClassReportView>> GetSupportedCommandClasses(byte id)
        {
            var nodes = await zwave.GetNodes();
            var supported = await nodes[id].GetSupportedCommandClasses();
            return supported.Select(i => new CommandClassReportView()
            {
                Class = i.Class,
                Version = i.Version,
                NodeId = i.Node.NodeID
            });
        }

        [HttpGet("{Id}")]
        public async Task<AlarmReport> Alarm(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Alarm>().Get();
        }

        //[HttpGet("{Id}")]
        //public async Task<byte> Association(byte id)
        //{
        //    var nodes = await zwave.GetNodes();
        //    var node = nodes[id];
        //    return await node.GetCommandClass<Association>().Get();
        //}

        [HttpGet("{Id}")]
        public async Task<BasicReport> Basic(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Basic>().Get();
        }

        [HttpGet("{Id}")]
        public async Task<BatteryReport> Battery(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Battery>().Get();
        }

        [HttpGet("{Id}")]
        public async Task<ClockReport> Clock(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Clock>().Get();
        }

        [HttpGet("{Id}/{ComponentId}")]
        public async Task<ColorReport> Color(byte id, byte componentId)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Color>().Get(componentId);
        }

        [HttpGet("{Id}/{Parameter}")]
        public async Task<ConfigurationReport> Configuration(byte id, byte parameter)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Configuration>().Get(parameter);
        }

        [HttpGet("{Id}")]
        public async Task<ManufacturerSpecificReport> ManufacturerSpecific(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<ManufacturerSpecific>().Get();
        }

        [HttpGet("{Id}")]
        public async Task<MeterReport> Meter(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<Meter>().Get();
        }

        //[HttpGet("{Id}")]
        //public async Task<byte[]> MultiChannel(byte id)
        //{
        //    var nodes = await zwave.GetNodes();
        //    var node = nodes[id];
        //    return await node.GetCommandClass<MultiChannel>().Get();
        //}

        //[HttpGet("{Id}")]
        //public async Task<SceneActivationReport> SceneActivation(byte id)
        //{
        //    var nodes = await zwave.GetNodes();
        //    var node = nodes[id];
        //    return await node.GetCommandClass<SceneActivation>().;
        //}

        [HttpGet("{Id}/{AlarmType}")]
        public async Task<SensorAlarmReport> SensorAlarm(byte id, AlarmType alarmType)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<SensorAlarm>().Get(alarmType);
        }

        [HttpGet("{Id}")]
        public async Task<SensorBinaryReport> SensorBinary(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<SensorBinary>().Get();
        }

        [HttpGet("{Id}")]
        public async Task<SensorMultiLevelReport> SensorMultiLevel(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<SensorMultiLevel>().Get();
        }

        [HttpGet("{Id}")]
        public async Task<SwitchBinaryReport> SwitchBinary(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<SwitchBinary>().Get();
        }

        [HttpGet("{Id}/Type")]
        public async Task<ThermostatSetpointReport> SwitchBinary(byte id, ThermostatSetpointType type)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<ThermostatSetpoint>().Get(type);
        }

        [HttpGet("{Id}")]
        public async Task<VersionReport> Version(byte id)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];
            return await node.GetCommandClass<global::ZWave.CommandClasses.Version>().Get();
        }

        //[HttpGet("{Id}")]
        //public async Task<WakeUpReport> WakeUp(byte id)
        //{
        //    var nodes = await zwave.GetNodes();
        //    var node = nodes[id];
        //    return await node.GetCommandClass<WakeUp>();
        //}
    }
}
