using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.ZWave.Models;
using ZWave;
using ZWave.Channel;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Repository
{
    public class SensorRepository<TSensorInfo, TTemp, TLight, THumidity, TUv>
        where TSensorInfo : ISensorInfoView, new()
        where TTemp : ISensorDataView, new()
        where TLight : ISensorDataView, new()
        where THumidity : ISensorDataView, new()
        where TUv : ISensorDataView, new()
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
        public SensorRepository(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        public async Task<IEnumerable<TSensorInfo>> List()
        {
            return new TSensorInfo[]{
                new TSensorInfo()
                {
                    Id = "3"
                }};
        }

        public async Task<TSensorInfo> Get(String id)
        {
            var query = await List();
            return query.First(i => i.Id == id);
        }

        public async Task<TTemp> Temperature(String id)
        {
            var report = await GetSensorData(id, SensorFarenheight);
            return new TTemp()
            {
                Value = report.Value,
                Units = Units.Fahrenheit
            };
        }

        public async Task<TLight> Light(String id)
        {
            var report = await GetSensorData(id, SensorLight);
            return new TLight()
            {
                Value = report.Value,
                Units = Units.Lux
            };
        }

        public async Task<THumidity> Humidity(String id)
        {
            var report = await GetSensorData(id, SensorHumidity);
            return new THumidity()
            {
                Value = report.Value,
                Units = Units.Percent
            };
        }

        public async Task<TUv> Uv(String id)
        {
            var report = await GetSensorData(id, SensorUv);
            return new TUv()
            {
                Value = report.Value,
                Units = Units.None
            };
        }

        private async Task<SensorMultiLevelReport2> GetSensorData(String id, byte sensor)
        {
            var byteId = byte.Parse(id);
            var nodes = await zwave.GetNodes();
            var node = nodes[byteId];

            var response = await zwave.Channel.Send(byteId, new Command(CommandClass.SensorMultiLevel, 0x04, sensor), 0x05);
            return new SensorMultiLevelReport2(node, response);
        }
    }
}
