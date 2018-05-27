using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Hue;
using Threax.Home.Hue.Repository;
using Threax.Home.Hue.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddHue(this IServiceCollection services, Action<HueConfig> configure)
        {
            var options = new HueConfig();
            configure?.Invoke(options);

            services.TryAddSingleton<IHueClientManager>(s =>
            {
                var manager = new HueClientManager();
                foreach (var client in options.Clients)
                {
                    manager.SetClient(client.Key, new SyncedHueClient(client.Value));
                }
                return manager;
            });

            services.TryAddScoped(typeof(IHueSwitchRepository<,>), typeof(HueSwitchRepository<,>));

            return services;
        }
    }
}
