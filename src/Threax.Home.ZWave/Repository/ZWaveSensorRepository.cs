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
    public class ZWaveSensorRepository<TSensor> : IZWaveSensorRepository<TSensor>, IDisposable
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
        public ZWaveSensorRepository(ZWaveController zwave, ZWaveConfig config)
        {
            this.zwave = zwave;
            this.config = config;
            this.zwave.Open();
        }

        public void Dispose()
        {
            this.zwave.Close();
        }

        public async Task<IEnumerable<TSensor>> List()
        {
            return new TSensor[]
            {
                await GetSensorData(config.ComPort, "1", AllSensors)
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
            //var nodes = await zwave.GetNodes();
            var node = await GetNode(byteId);

            var sensorInfo = new TSensor()
            {
                Id = id,
                Bridge = bridge,
                Subsystem = SubsystemName
            };

            foreach (var sensor in sensors)
            {
                var commandClass = node.GetCommandClass<SensorMultiLevel>();
                switch (sensor)
                {
                    case Sensor.SensorFarenheight:
                        sensorInfo.TempUnits = Units.Fahrenheit;
                        sensorInfo.TempValue = (await commandClass.Get(SensorType.Temperature)).Value;
                        break;
                    case Sensor.SensorHumidity:
                        sensorInfo.TempUnits = Units.Percent;
                        sensorInfo.TempValue = (await commandClass.Get(SensorType.RelativeHumidity)).Value;
                        break;
                    case Sensor.SensorLight:
                        sensorInfo.TempUnits = Units.Lux;
                        sensorInfo.TempValue = (await commandClass.Get(SensorType.Luminance)).Value;
                        break;
                    case Sensor.SensorUv:
                        sensorInfo.TempUnits = Units.None;
                        sensorInfo.TempValue = (await commandClass.Get(SensorType.Ultraviolet)).Value;
                        break;
                }
            }

            return sensorInfo;
        }
    }
}
