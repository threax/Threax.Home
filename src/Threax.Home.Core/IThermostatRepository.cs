using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface IThermostatRepository
    {
        String SubsystemName { get; }
    }

    public interface IThermostatRepository<TIn, TOut> : ISensorRepository
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        Task<TOut> Get(string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }
}
