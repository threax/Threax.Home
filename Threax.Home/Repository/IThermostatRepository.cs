using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;

namespace Threax.Home.Repository
{
    public partial interface IThermostatRepository
    {
        Task<Thermostat> Add(ThermostatInput value);
        Task AddRange(IEnumerable<ThermostatInput> values);
        Task Delete(Guid id);
        Task<Thermostat> Get(Guid thermostatId);
        Task<bool> HasThermostats();
        Task<ThermostatCollection> List(ThermostatQuery query);
        Task<Thermostat> Update(Guid thermostatId, ICoreThermostatSetting value);
        Task AddMissing(IEnumerable<Thermostat> items);
    }
}