using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Threax.Home.Client
{
    public interface IHomeClient
    {
        Task<SwitchResult> GetSwitch(string id);
        Task<IEnumerable<SwitchResult>> GetSwitches();
        Task SendCommandAsync(SetSwitchInput command, IEnumerable<string> lightList = null);
        Task<ThermostatResult> GetThermostat(string id);
        Task<IEnumerable<ThermostatResult>> GetThermostats();
    }
}