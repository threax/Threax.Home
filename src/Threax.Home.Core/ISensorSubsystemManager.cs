using System.Collections.Generic;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface ISensorSubsystemManager<TSensor> : ISensorSubsystemConfiguration
        where TSensor : ISensor, new()
    {
        Task<TSensor> Get(string subsystem, string bridge, string id);
        Task<IEnumerable<TSensor>> List();
    }
}