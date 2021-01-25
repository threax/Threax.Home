using System;
using System.Threading.Tasks;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWaveInspect
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // create the controller
            var controller = new ZWaveController("COM3");

            // open the controller
            controller.Open();

            foreach (var node in await controller.GetNodes())
            {
                Console.WriteLine(node.NodeID);

                var protocolInfo = await node.GetProtocolInfo();
                Console.WriteLine(protocolInfo.BasicType);
                Console.WriteLine(protocolInfo.GenericType);

                var cces = await node.GetSupportedCommandClasses();
                foreach(var cc in cces)
                {
                    Console.WriteLine($"{cc.Class} {cc.Version}");
                }

                if (protocolInfo.GenericType == GenericType.Thermostat)
                {
                    var mode = node.GetCommandClass<ThermostatMode>();
                    //await mode.Set(ThermostatModeValue.Auto);
                    var modeReport = await mode.Get();
                    Console.WriteLine($"Thermostat Mode: {modeReport.Mode}");

                    var fanMode = node.GetCommandClass<ThermostatFanMode>();
                    var fanModeReport = await fanMode.Get();
                    Console.WriteLine($"Fan Mode: {fanModeReport.Mode}");

                    var setpoint = node.GetCommandClass<ThermostatSetpoint>();
                    //await setpoint.Set(ThermostatSetpointType.Cooling, FloatToCentigrade(85));
                    var coolingReport = await setpoint.Get(ThermostatSetpointType.Cooling);
                    Console.WriteLine($"Cooling Setpoint: {coolingReport.Value}");
                    //await setpoint.Set(ThermostatSetpointType.Heating, FloatToCentigrade(65));
                    var heatingReport = await setpoint.Get(ThermostatSetpointType.Heating);
                    Console.WriteLine($"Heating Setpoint: {heatingReport.Value}");

                    var battery = node.GetCommandClass<Battery>();
                    var batteryReport = await battery.Get();
                    Console.WriteLine($"Battery: {batteryReport.Value}");

                    var sensor = node.GetCommandClass<SensorMultiLevel>();
                    var supportedSensorReport = await sensor.GetSupportedSensors();
                    foreach(var sensorInfo in supportedSensorReport.SupportedSensorTypes)
                    {
                        var value = await sensor.Get(sensorInfo);
                        Console.WriteLine($"{sensorInfo}: {value.Value} {value.Unit}");
                    }

                    var operatingState = node.GetCommandClass<ThermostatOperatingState>();
                    var operatingStateReport = await operatingState.Get();
                    Console.WriteLine($"Operating State: {operatingStateReport.Value}");

                    var fanState = node.GetCommandClass<ThermostatFanState>();
                    var fanStateReport = await fanState.Get();
                    Console.WriteLine($"Fan State: {fanStateReport.Value}");
                }

                if (protocolInfo.GenericType == GenericType.SwitchBinary)
                {
                    var setpoint = node.GetCommandClass<SwitchBinary>();
                    //await setpoint.Set(false);
                    var setpointReport = await setpoint.Get();
                    Console.WriteLine(setpointReport.Value);
                }

                Console.WriteLine();
            }
        }

        private static float FloatToCentigrade(float farenheight)
        {
            return (farenheight - 32.0f) / 1.8000f;
        }
    }
}
