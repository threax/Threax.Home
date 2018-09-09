using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AppTemplateClient;
using System;
using Threax.AspNetCore.Halcyon.Client;
using Threax.Home.Client;
using Threax.AspNetCore.AuthCore;
using Threax.Home.Client.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add the AppTemplate setup to use client credentials to connect to the service.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">The configure callback.</param>
        /// <returns></returns>
        public static IServiceCollection AddHomeClient(this IServiceCollection services, Action<HomeClientOptions> configure)
        {
            var options = new HomeClientOptions();
            configure?.Invoke(options);

            services.TryAddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();

            services.TryAddSingleton<IHomeClientManager>(s =>
            {
                var manager = new HomeClientManager();
                if (options.Clients != null)
                {
                    foreach (var client in options.Clients)
                    {
                        var clientCredsFactory = new ClientCredentialsAccessTokenFactory<EntryPointInjector>(client.Value.ClientCredentials, new BearerHttpClientFactory<EntryPointInjector>(s.GetRequiredService<IHttpClientFactory>()));
                        var entryPointInjector = new EntryPointInjector(client.Value.ServiceUrl, clientCredsFactory);
                        manager.SetClient(client.Key, new HomeClient(entryPointInjector));
                    }
                }
                return manager;
            });

            services.TryAddScoped(typeof(IClientSwitchRepository<,>), typeof(ClientSwitchRepository<,>));

            services.AdditionalSwitchConfiguration(o =>
            {
                o.AddSwitch(typeof(IClientSwitchRepository<,>));
            });

            return services;
        }
    }
}
