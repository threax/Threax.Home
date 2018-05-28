using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.ZWave;
using Threax.Home.ZWave.Repository;
using ZWave;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddZWave(this IServiceCollection services, Action<ZWaveConfig> configure)
        {
            var options = new ZWaveConfig();
            configure?.Invoke(options);

            services.TryAddSingleton<ZWaveConfig>(options);
            services.TryAddSingleton<ZWaveController>(s =>
            {
                return new ZWaveController(options.ComPort);
            });

            services.TryAddScoped(typeof(IZWaveSwitchRepository<,>), typeof(ZWaveSwitchRepository<,>));

            return services;
        }
    }
}
