using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.LibCec.Repository
{
    public interface ICecSwitchRepository<TIn, TOut> : ISwitchRepository<TIn, TOut>
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
    }
}