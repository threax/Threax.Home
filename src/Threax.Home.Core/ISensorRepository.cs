using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface ISensorRepository
    {
        String SubsystemName { get; }
    }

    public interface ISensorRepository<TSensor>
        where TSensor : ISensor, new()
    {
        Task<TSensor> Get(string bridge, string id);
        Task<IEnumerable<TSensor>> List();
    }
}
