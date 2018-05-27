using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class SwitchSubsystemManager<TIn, TOut> : ISwitchSubsystemManager<TIn, TOut>
        where TIn : ISwitch, new()
        where TOut : ISwitch, new()
    {
        private Dictionary<String, ISwitchRepository<TIn, TOut>> switchRepos = new Dictionary<string, ISwitchRepository<TIn, TOut>>();
        private IHttpContextAccessor httpContextAccessor;

        public SwitchSubsystemManager(HomeConfig config, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            config.SetupConfigs(this);
        }

        public Type TInType => typeof(TIn);

        public Type TOutType => typeof(TOut);

        public IServiceProvider Services => httpContextAccessor.HttpContext.RequestServices;

        public void AddSubsystem(ISwitchRepository switchRepo)
        {
            switchRepos.Add(switchRepo.SubsystemName, (ISwitchRepository<TIn, TOut>)switchRepo);
        }

        public Task<TOut> Get(string subsystem, string bridge, string id)
        {
            return switchRepos[subsystem].Get(bridge, id);
        }

        public async Task<IEnumerable<TOut>> List()
        {
            var result = new List<TOut>();

            foreach (var subsystem in switchRepos.Values)
            {
                result.AddRange(await subsystem.List());
            }

            return result;
        }

        public Task Set(TIn setting)
        {
            return switchRepos[setting.Subsystem].Set(setting);
        }
    }
}
