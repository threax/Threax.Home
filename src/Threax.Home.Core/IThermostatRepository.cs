using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public interface IThermostatRepository
    {
        String SubsystemName { get; }
    }

    public interface IThermostatRepository<TThermostat> : ISensorRepository
        where TThermostat : IThermostat, new()
    {
        Task<TThermostat> Get(string bridge, string id);
        Task<IEnumerable<TThermostat>> List();
    }
}
