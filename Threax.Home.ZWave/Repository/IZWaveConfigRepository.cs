using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.ZWave.Models;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Repository
{
    public interface IZWaveConfigRepository
    {
        Task<AlarmReport> Alarm(byte id);
        Task<BasicReport> Basic(byte id);
        Task<BatteryReport> Battery(byte id);
        Task<ClockReport> Clock(byte id);
        Task<ColorReport> Color(byte id, byte componentId);
        Task<ConfigurationReport> Configuration(byte id, byte parameter);
        Task<IEnumerable<CommandClassReportView>> GetSupportedCommandClasses(byte id);
        Task<ManufacturerSpecificReport> ManufacturerSpecific(byte id);
        Task<MeterReport> Meter(byte id);
        Task<SensorAlarmReport> SensorAlarm(byte id, AlarmType alarmType);
        Task<SensorBinaryReport> SensorBinary(byte id);
        Task<SwitchBinaryReport> SwitchBinary(byte id);
        Task<ThermostatSetpointReport> SwitchBinary(byte id, ThermostatSetpointType type);
        Task<VersionReport> Version(byte id);
    }
}