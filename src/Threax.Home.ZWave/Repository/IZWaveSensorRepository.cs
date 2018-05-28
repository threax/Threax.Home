using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.ZWave.Repository
{
    public interface IZWaveSensorRepository<TSensor> : ISensorRepository<TSensor>
        where TSensor : ICoreSensor, new()
    {
        
    }
}