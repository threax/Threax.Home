using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core.ViewModels;
using ZWave;
using ZWave.Channel;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]/[action]")]
    public class SensorController : Controller
    {
        private const byte SensorFarenheight = 2;
        private const byte SensorLight = 3;
        private const byte SensorHumidity = 5;
        private const byte SensorUv = 27;

        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public SensorController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet("{id}")]
        public async Task<SensorDataView> Temperature(byte id)
        {
            var report = await GetSensorData(id, SensorFarenheight);
            return new SensorDataView()
            {
                Value = report.Value,
                Units = Units.Fahrenheit
            };
        }

        [HttpGet("{id}")]
        public async Task<SensorDataView> Light(byte id)
        {
            var report = await GetSensorData(id, SensorLight);
            return new SensorDataView()
            {
                Value = report.Value,
                Units = Units.Lux
            };
        }

        [HttpGet("{id}")]
        public async Task<SensorDataView> Humidity(byte id)
        {
            var report = await GetSensorData(id, SensorHumidity);
            return new SensorDataView()
            {
                Value = report.Value,
                Units = Units.Percent
            };
        }

        [HttpGet("{id}")]
        public async Task<SensorDataView> Uv(byte id)
        {
            var report = await GetSensorData(id, SensorUv);
            return new SensorDataView()
            {
                Value = report.Value,
                Units = Units.None
            };
        }

        private async Task<SensorMultiLevelReport2> GetSensorData(byte id, byte sensor)
        {
            var nodes = await zwave.GetNodes();
            var node = nodes[id];

            var response = await zwave.Channel.Send(id, new Command(CommandClass.SensorMultiLevel, 0x04, sensor), 0x05);
            return new SensorMultiLevelReport2(node, response);
        }
    }
}
