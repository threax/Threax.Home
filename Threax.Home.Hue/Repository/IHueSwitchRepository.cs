using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Hue.Repository
{
    public interface IHueSwitchRepository<TIn, TOut>
        where TIn : ISwitch, new()
        where TOut : ISwitch, new()
    {
        Task<TOut> Get(string bridge, string id);
        Task<IEnumerable<TOut>> List();
        Task Set(TIn setting);
    }
}