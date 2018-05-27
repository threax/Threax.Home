using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection SetupSwitches(this IServiceCollection services, Action<HomeConfig> configure)
        {
            var options = new HomeConfig();
            configure?.Invoke(options);

            services.TryAddSingleton(options);
            services.TryAddScoped(typeof(ISwitchSubsystemManager<,>), typeof(SwitchSubsystemManager<,>));

            return services;
        }
    }
}
