using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class SwitchSubsystemManager<TIn, TOut> : ISwitchSubsystemManager<TIn, TOut>
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        private Dictionary<String, ISwitchRepository<TIn, TOut>> switchRepos = new Dictionary<string, ISwitchRepository<TIn, TOut>>();
        private IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<SwitchSubsystemManager<TIn, TOut>> logger;

        public SwitchSubsystemManager(HomeConfig config, IHttpContextAccessor httpContextAccessor, ILogger<SwitchSubsystemManager<TIn, TOut>> logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
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
                try
                {
                    result.AddRange(await subsystem.List());
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"'{ex.GetType().FullName}' occured with the loading switches. The subsystem '{subsystem.SubsystemName}' was skipped.{Environment.NewLine}Full Exception:");
                }
            }

            return result;
        }

        public Task Set(TIn setting)
        {
            return switchRepos[setting.Subsystem].Set(setting);
        }
    }
}
