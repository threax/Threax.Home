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
    public class ZWaveSensorRepository<TSensor> : IZWaveSensorRepository<TSensor>
        where TSensor : ICoreSensor, new()
    {
        enum Sensor : byte
        {
            SensorFarenheight = 2,
            SensorLight = 3,
            SensorHumidity = 5,
            SensorUv = 27,
        }

        private static readonly Sensor[] AllSensors = new Sensor[] { Sensor.SensorFarenheight, Sensor.SensorHumidity, Sensor.SensorLight, Sensor.SensorUv };

        public string SubsystemName => "ZWave";

        private ZWaveController zwave;
        private ZWaveConfig config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        /// <param name="config">The config.</param>
        public ZWaveSensorRepository(IZWaveControllerAccessor zwave, ZWaveConfig config)
        {
            this.zwave = zwave.Controller;
            this.config = config;
        }

        public async Task<IEnumerable<TSensor>> List()
        {
            var sensor = await GetSensorData(config.ComPort, "6", AllSensors);
            sensor.Name = "Outdoor Rear";
            return new TSensor[]
            {
                sensor
            };
        }

        public async Task<TSensor> Get(String bridge, String id)
        {
            var result = await GetSensorData(bridge, id, AllSensors);
            return result;
        }

        private async Task<Node> GetNode(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId);
        }

        private async Task<TSensor> GetSensorData(String bridge, String id, IEnumerable<Sensor> sensors)
        {
            var byteId = byte.Parse(id);
            var nodes = await zwave.GetNodes();
            var node = await GetNode(byteId);

            var sensorInfo = new TSensor()
            {
                Id = id,
                Bridge = bridge,
                Subsystem = SubsystemName
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
                        sensorInfo.HumidityUnits = Units.Percent;
                        sensorInfo.HumidityValue = report.Value;
                        break;
                    case Sensor.SensorLight:
                        sensorInfo.LightUnits = Units.Lux;
                        sensorInfo.LightValue = report.Value;
                        break;
                    case Sensor.SensorUv:
                        sensorInfo.UvUnits = Units.None;
                        sensorInfo.UvValue = report.Value;
                        break;
                }
            }

            return sensorInfo;
        }
    }
}
