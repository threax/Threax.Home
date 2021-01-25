using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.ZWave.Repository
{
    public interface IZWaveThermostatRepository<TIn, TOut> : IThermostatRepository<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        
    }
}