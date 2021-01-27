using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Repository
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class ZWaveThermostatRepository<TIn, TOut> : IZWaveThermostatRepository<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        private ZWaveController zwave;
        private ZWaveConfig config;

        public string SubsystemName => "ZWave";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        /// <param name="config">The config</param>
        public ZWaveThermostatRepository(IZWaveControllerAccessor zwave, ZWaveConfig config)
        {
            this.zwave = zwave.Controller;
            this.config = config;
        }

        public async Task<TOut> Get(string bridge, string id)
        {
            var byteId = byte.Parse(id);
            var node = await GetNode(byteId);
            var thermostatModeCC = node.GetCommandClass<ThermostatMode>();
            var thermostatFanModeCC = node.GetCommandClass<ThermostatFanMode>();
            var setpointCC = node.GetCommandClass<ThermostatSetpoint>();
            var operatingStateCC = node.GetCommandClass<ThermostatOperatingState>();
            var sensorCC = node.GetCommandClass<SensorMultiLevel>();
            var fanStateCC = node.GetCommandClass<ThermostatFanState>();

            Mode mode;
            switch((await thermostatModeCC.Get()).Mode)
            {
                case ThermostatModeValue.Auto:
                case ThermostatModeValue.AutoChangeover:
                    mode = Mode.Auto;
                    break;
                case ThermostatModeValue.Cool:
                case ThermostatModeValue.EnergyCool:
                    mode = Mode.Cool;
                    break;
                case ThermostatModeValue.Heat:
                case ThermostatModeValue.EnergyHeat:
                    mode = Mode.Heat;
                    break;
                case ThermostatModeValue.Off:
                    mode = Mode.Off;
                    break;
                default:
                    mode = Mode.Unknown;
                    break;
            }

            FanSetting fanSetting;
            switch ((await thermostatFanModeCC.Get()).Mode)
            {
                case ThermostatFanModeValue.AutoHigh:
                case ThermostatFanModeValue.AutoLow:
                case ThermostatFanModeValue.AutoMedium:
                    fanSetting = FanSetting.Auto;
                    break;

                default:
                    fanSetting = FanSetting.On;
                    break;
            }

            State state;
            switch ((await operatingStateCC.Get()).Value)
            {
                case ThermostatOperatingStateValue.Idle:
                case ThermostatOperatingStateValue.FanOnly:
                    state = State.Idle;
                    break;
                case ThermostatOperatingStateValue.Heating:
                case ThermostatOperatingStateValue.PendingHeat:
                case ThermostatOperatingStateValue.SecondStageHeating:
                case ThermostatOperatingStateValue.AuxHeating:
                    state = State.Heating;
                    break;
                case ThermostatOperatingStateValue.Cooling:
                case ThermostatOperatingStateValue.PendingCool:
                case ThermostatOperatingStateValue.SecondStageCooling:
                    state = State.Cooling;
                    break;
                default:
                    state = State.Unknown;
                    break;
            }

            FanState fanState;
            switch ((await fanStateCC.Get()).Value)
            {
                case ThermostatFanStateValue.Off:
                    fanState = FanState.Off;
                    break;
                case ThermostatFanStateValue.Running:
                default: //Consider any other values to be on
                    fanState = FanState.On;
                    break;
            }

            return new TOut()
            {
                Id = id,
                Bridge = bridge,
                Subsystem = SubsystemName,
                Name = $"{SubsystemName} Node {node.NodeID}",
                HeatTemp = (int)(await setpointCC.Get(ThermostatSetpointType.Heating)).Value,
                CoolTemp = (int)(await setpointCC.Get(ThermostatSetpointType.Cooling)).Value,
                Mode = mode,
                Fan = fanSetting,
                State = state,
                FanState = fanState,
                SpaceTemp = (int)(await sensorCC.Get(SensorType.Temperature)).Value,
                Humidity = (int)(await sensorCC.Get(SensorType.RelativeHumidity)).Value,
            };
        }

        public async Task Set(TIn setting)
        {
            var byteId = byte.Parse(setting.Id);
            var node = await GetNode(byteId);
            var thermostatModeCC = node.GetCommandClass<ThermostatMode>();
            var thermostatFanModeCC = node.GetCommandClass<ThermostatFanMode>();
            var setpointCC = node.GetCommandClass<ThermostatSetpoint>();

            ThermostatModeValue thermostatMode;
            switch (setting.Mode)
            {
                case Mode.Auto:
                    thermostatMode = ThermostatModeValue.Auto;
                    break;
                case Mode.Heat:
                    thermostatMode = ThermostatModeValue.Heat;
                    break;
                case Mode.Cool:
                    thermostatMode = ThermostatModeValue.Cool;
                    break;
                case Mode.Off:
                default: //Consider anything unknown to be off
                    thermostatMode = ThermostatModeValue.Off;
                    break;
            }

            ThermostatFanModeValue fanMode;
            switch (setting.Fan)
            {
                case FanSetting.Auto:
                default: //Consider anything unknown to be auto
                    fanMode = ThermostatFanModeValue.AutoLow;
                    break;
                case FanSetting.On:
                    fanMode = ThermostatFanModeValue.Low;
                    break;
            }

            await thermostatModeCC.Set(thermostatMode);
            await thermostatFanModeCC.Set(fanMode);
            await setpointCC.Set(ThermostatSetpointType.Cooling, FarenheightToCentigrade(setting.CoolTemp));
            await setpointCC.Set(ThermostatSetpointType.Heating, FarenheightToCentigrade(setting.HeatTemp));
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var results = new List<TOut>();

            foreach(var node in await zwave.GetNodes())
            {
                var protocolInfo = await node.GetProtocolInfo();
                switch (protocolInfo.GenericType)
                {
                    case GenericType.Thermostat:
                        var stat = await Get(config.ComPort, node.NodeID.ToString());
                        results.Add(stat);
                        break;
                }
            }

            return results;
        }

        private async Task<Node> GetNode(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId);
        }

        private static float FarenheightToCentigrade(float farenheight)
        {
            return (farenheight - 32.0f) / 1.8000f;
        }
    }
}
