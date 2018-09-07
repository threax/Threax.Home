using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Repository
{
    public partial interface IThermostatSettingRepository
    {
        Task<ThermostatSetting> Add(ThermostatSettingInput value);
        Task AddRange(IEnumerable<ThermostatSettingInput> values);
        Task Delete(Guid id);
        Task<ThermostatSetting> Get(Guid thermostatSettingId);
        Task<bool> HasThermostatSettings();
        Task<ThermostatSettingCollection> List(ThermostatSettingQuery query);
        Task<ThermostatSetting> Update(Guid thermostatSettingId, ThermostatSettingInput value);
    }
}