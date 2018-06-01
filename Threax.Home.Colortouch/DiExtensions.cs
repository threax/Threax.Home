using ColorTouchSharp;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Threax.Home.Colortouch;

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
                services.TryAddSingleton<ColorTouchConfig>(options);
                services.TryAddSingleton<IColorTouchClientManager>(s =>
                {
                    var manager = new ColorTouchClientManager();
                    var httpClient = s.GetRequiredService<HttpClient>();

                    foreach (var client in options.Clients)
                    {
                        manager.AddClient(new ColorTouchClient(client.Key, client.Value.Host, httpClient));
                    }

                    return manager;
                });

                //services.TryAddScoped(typeof(IZWaveSwitchRepository<,>), typeof(ZWaveSwitchRepository<,>));
                //services.TryAddScoped(typeof(IZWaveSensorRepository<>), typeof(ZWaveSensorRepository<>));

                //services.AdditionalSwitchConfiguration(o =>
                //{
                //    o.AddSwitch(typeof(IZWaveSwitchRepository<,>));
                //    o.AddSensor(typeof(IZWaveSensorRepository<>));
                //});
            }

            return services;
        }
    }
}
