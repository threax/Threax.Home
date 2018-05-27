using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Hue.Repository
{
    public interface IHueSwitchRepository<T>
        where T : ISwitch, new()
    {
        Task<T> Get(string bridge, string id);
        Task<IEnumerable<T>> List();
        Task Set(T setting);
    }
}