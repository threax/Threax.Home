using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.ZWave.Models;
using Threax.Home.ZWave.ViewModels;
using ZWave;
using ZWave.Channel;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]/[action]")]
    [ResponseCache(NoStore = true)]
    public class SensorController : Controller
    {
        private const byte SensorFarenheight = 2;
        private const byte SensorLight = 3;
        private const byte SensorHumidity = 5;
        private const byte SensorUv = 27;

        public static class Rels
        {
            public const String ListSensors = "ListSensors";
            public const String GetTemperature = "GetTemperature";
            public const String GetLight = "GetLight";
            public const String GetHumidity = "GetHumidity";
            public const String GetUv = "GetUv";
            public const String GetSensor = "GetSensor";
        }

        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public SensorController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        [HttpGet]
        [HalRel(Rels.ListSensors)]
        public async Task<SensorInfoCollectionView> List()
        {
            return new SensorInfoCollectionView(new SensorInfoView[]
            {
                new SensorInfoView()
                {
                    Id = 3
                }
            });
        }

        [HttpGet("{Id}")]
        [HalRel(Rels.GetSensor)]
        public async Task<SensorInfoView> Get(byte id)
        {
            var query = await List();
            return query.Items.First(i => i.Id == id);
        }

        [HttpGet("{Id}")]
        [HalRel(Rels.GetTemperature)]
        public async Task<TemperatureDataView> Temperature(byte id)
        {
            var report = await GetSensorData(id, SensorFarenheight);
            return new TemperatureDataView()
            {
                Value = report.Value,
                Units = Units.Fahrenheit
            };
        }

        [HttpGet("{Id}")]
        [HalRel(Rels.GetLight)]
        public async Task<LightDataView> Light(byte id)
        {
            var report = await GetSensorData(id, SensorLight);
            return new LightDataView()
            {
                Value = report.Value,
                Units = Units.Lux
            };
        }

        [HttpGet("{Id}")]
        [HalRel(Rels.GetHumidity)]
        public async Task<HumidityDataView> Humidity(byte id)
        {
            var report = await GetSensorData(id, SensorHumidity);
            return new HumidityDataView()
            {
                Value = report.Value,
                Units = Units.Percent
            };
        }

        [HttpGet("{Id}")]
        [HalRel(Rels.GetUv)]
        public async Task<UvDataView> Uv(byte id)
        {
            var report = await GetSensorData(id, SensorUv);
            return new UvDataView()
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
