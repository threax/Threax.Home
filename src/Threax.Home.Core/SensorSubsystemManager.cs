using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class SensorSubsystemManager<TSensor> : ISensorSubsystemManager<TSensor>
        where TSensor : ICoreSensor, new()
    {
        private Dictionary<String, ISensorRepository<TSensor>> switchRepos = new Dictionary<string, ISensorRepository<TSensor>>();
        private IHttpContextAccessor httpContextAccessor;

        public SensorSubsystemManager(HomeConfig config, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            config.SetupConfigs(this);
        }

        public Type TSensorType => typeof(TSensor);

        public IServiceProvider Services => httpContextAccessor.HttpContext.RequestServices;

        public void AddSubsystem(ISensorRepository switchRepo)
        {
            switchRepos.Add(switchRepo.SubsystemName, (ISensorRepository<TSensor>)switchRepo);
        }

        public Task<TSensor> Get(string subsystem, string bridge, string id)
        {
            return switchRepos[subsystem].Get(bridge, id);
        }

        public async Task<IEnumerable<TSensor>> List()
        {
            var result = new List<TSensor>();

            foreach (var subsystem in switchRepos.Values)
            {
                result.AddRange(await subsystem.List());
            }

            return result;
        }
    }
}
