using ColorTouchSharp;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Threax.Home.Colortouch;
using Threax.Home.Colortouch.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddColorTouch(this IServiceCollection services, Action<ColorTouchConfig> configure)
        {
            var options = new ColorTouchConfig();
            configure?.Invoke(options);

            if (options.Enabled)
            {
                services.TryAddScoped<HttpClient>();
                services.TryAddSingleton<ColorTouchConfig>(options);
                services.TryAddScoped<IColorTouchClientManager>(s =>
                {
                    var manager = new ColorTouchClientManager();
                    var httpClient = s.GetRequiredService<HttpClient>();

                    foreach (var client in options.Clients)
                    {
                        manager.AddClient(new ColorTouchClient(client.Key, client.Value.Host, httpClient));
                    }

                    return manager;
                });

                services.TryAddScoped(typeof(IColorTouchThermostatRepository<,>), typeof(ColorTouchThermostatRepository<,>));

                services.AdditionalSwitchConfiguration(o =>
                {
                    o.AddThermostat(typeof(IColorTouchThermostatRepository<,>));
                });
            }

            return services;
        }
    }
}
