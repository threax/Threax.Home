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
        static HomeConfig options = new HomeConfig();

        public static IServiceCollection SetupSwitches(this IServiceCollection services, Action<HomeConfig> configure = null)
        {
            configure?.Invoke(options);

            services.TryAddSingleton(options);
            services.TryAddScoped(typeof(ISwitchSubsystemManager<,>), typeof(SwitchSubsystemManager<,>));
            services.TryAddScoped(typeof(ISensorSubsystemManager<>), typeof(SensorSubsystemManager<>));
            services.TryAddScoped(typeof(IThermostatSubsystemManager<,>), typeof(ThermostatSubsystemManager<,>));

            return services;
        }

        public static IServiceCollection AdditionalSwitchConfiguration(this IServiceCollection services, Action<HomeConfig> configure)
        {
            configure?.Invoke(options);

            return services;
        }
    }
}
