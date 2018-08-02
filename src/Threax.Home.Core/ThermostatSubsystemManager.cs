using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class ThermostatSubsystemManager<TIn, TOut> : IThermostatSubsystemManager<TIn, TOut>
        where TIn : ICoreThermostatSetting, new()
        where TOut : ICoreThermostat, new()
    {
        private Dictionary<String, IThermostatRepository<TIn, TOut>> switchRepos = new Dictionary<string, IThermostatRepository<TIn, TOut>>();
        private IHttpContextAccessor httpContextAccessor;

        public ThermostatSubsystemManager(HomeConfig config, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            config.SetupConfigs(this);
        }

        public Type TInType => typeof(TIn);

        public Type TOutType => typeof(TOut);

        public IServiceProvider Services => httpContextAccessor.HttpContext.RequestServices;

        public void AddSubsystem(IThermostatRepository switchRepo)
        {
            switchRepos.Add(switchRepo.SubsystemName, (IThermostatRepository<TIn, TOut>)switchRepo);
        }

        public Task<TOut> Get(string subsystem, string bridge, string id)
        {
            var repo = switchRepos[subsystem];
            return repo.Get(bridge, id);
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var results = new List<TOut>();
            foreach(var repo in switchRepos.Values)
            {
                results.AddRange(await repo.List());
            }
            return results;
        }

        public Task Set(TIn setting)
        {
            var repo = switchRepos[setting.Subsystem];
            return repo.Set(setting);
        }
    }
}
