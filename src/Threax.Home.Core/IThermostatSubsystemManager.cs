using System.Collections.Generic;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface IThermostatSubsystemManager<TIn, TOut> : IThermostatRepositorySubsystemConfiguration
        where TIn : IThermostatSetting, new()
        where TOut : IThermostat, new()
    {
        Task<TOut> Get(string subsystem, string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }
}