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
    public class ZWaveSensorRepository<TSensorInfo>
        where TSensorInfo : ISensor, new()
    {
        enum Sensor : byte
        {
            SensorFarenheight = 2,
            SensorLight = 3,
            SensorHumidity = 5,
            SensorUv = 27,
        }

        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public ZWaveSensorRepository(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        public async Task<IEnumerable<TSensorInfo>> List()
        {
            return new TSensorInfo[]
            {
                await GetSensorData("3", new Sensor[]{ Sensor.SensorFarenheight, Sensor.SensorHumidity, Sensor.SensorLight, Sensor.SensorUv })
            };
        }

        public async Task<TSensorInfo> Get(String id)
        {
            var query = await List();
            return query.First(i => i.Id == id);
        }

        private async Task<TSensorInfo> GetSensorData(String id, IEnumerable<Sensor> sensors)
        {
            var byteId = byte.Parse(id);
            var nodes = await zwave.GetNodes();
            var node = nodes[byteId];

            var sensorInfo = new TSensorInfo()
            {
                Id = id
            };

            foreach (var sensor in sensors)
            {
                var response = await zwave.Channel.Send(byteId, new Command(CommandClass.SensorMultiLevel, 0x04, (byte)sensor), 0x05);
                var report = new SensorMultiLevelReport2(node, response);
                switch (sensor)
                {
                    case Sensor.SensorFarenheight:
                        sensorInfo.TempUnits = Units.Fahrenheit;
                        sensorInfo.TempValue = report.Value;
                        break;
                    case Sensor.SensorHumidity:
                        sensorInfo.TempUnits = Units.Percent;
                        sensorInfo.TempValue = report.Value;
                        break;
                    case Sensor.SensorLight:
                        sensorInfo.TempUnits = Units.Lux;
                        sensorInfo.TempValue = report.Value;
                        break;
                    case Sensor.SensorUv:
                        sensorInfo.TempUnits = Units.None;
                        sensorInfo.TempValue = report.Value;
                        break;
                }
            }

            return sensorInfo;
        }
    }
}
