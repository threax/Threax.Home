using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.MFi;
using Threax.Home.MFi.Services;
using Threax.Home.MFi.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddMfi(this IServiceCollection services, Action<MfiConfig> configure)
        {
            var options = new MfiConfig();
            configure?.Invoke(options);

            services.TryAddSingleton<IPowerStripManager>(s =>
            {
                var manager = new PowerStripManager();
                foreach (var client in options.Clients)
                {

                    manager.SetClient(client.Key, new SynchedPowerStrip(new MfiSharp.PowerStrip(client.Value)));
                }
                return manager;
            });

            services.TryAddScoped(typeof(IMfiSwitchRepository<,>), typeof(MfiSwitchRepository<,>));

            services.AdditionalSwitchConfiguration(o =>
            {
                o.AddSwitch(typeof(IMfiSwitchRepository<,>));
            });

            return services;
        }
    }
}
