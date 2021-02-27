using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Client.Repository
{
    public interface IClientThermostatRepository<TIn, TOut> : IThermostatRepository<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        
    }
}