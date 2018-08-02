using System.Collections.Generic;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface ISwitchSubsystemManager<TIn, TOut> : ISwitchSubsystemConfiguration
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        Task<TOut> Get(string subsystem, string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }
}