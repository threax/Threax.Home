using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Threax.Home.WinLirc;
using Threax.Home.WinLirc.Repository;
using Threax.Home.WinLirc.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddWinLirc(this IServiceCollection services, Action<WinLircConfig> configure)
        {
            var options = new WinLircConfig();
            configure?.Invoke(options);

            services.TryAddSingleton<IWinLircManager, WinLircManager>();
            services.TryAddScoped(typeof(IWinLircSwitchRepository<,>), typeof(WinLircSwitchRepository<,>));

            services.AdditionalSwitchConfiguration(o =>
            {
                o.AddSwitch(typeof(IWinLircSwitchRepository<,>));
            });

            return services;
        }
    }
}
