using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.LibCec;
using Threax.Home.LibCec.Services;
using Threax.Home.LibCec.Repository;
using libCecCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddLibCec(this IServiceCollection services, Action<LibCecConfig> configure)
        {
            var options = new LibCecConfig();
            configure?.Invoke(options);

            if (options.Enabled)
            {
                services.TryAddSingleton<ICecManager>(s =>
                {
                    var cecManager = new CecManager(options.Port);
                    cecManager.Start();
                    return cecManager;
                });
                services.TryAddSingleton<ICecManagerService, CecManagerService>();

                services.TryAddScoped(typeof(ICecSwitchRepository<,>), typeof(CecSwitchRepository<,>));

                services.AdditionalSwitchConfiguration(o =>
                {
                    o.AddSwitch(typeof(ICecSwitchRepository<,>));
                });
            }

            return services;
        }
    }
}
