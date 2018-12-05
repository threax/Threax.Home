using Threax.Home.Core;

namespace Threax.Home.WinLirc.Repository
{
    public interface IWinLircSwitchRepository<TIn, TOut> : ISwitchRepository<TIn, TOut>
       where TIn : ICoreSwitch, new()
       where TOut : ICoreSwitch, new()
    {
        
    }
}
