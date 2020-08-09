using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AppTemplateClient;
using System;
using Threax.AspNetCore.Halcyon.Client;
using Threax.Home.Client;
using Threax.AspNetCore.AuthCore;
using Threax.Home.Client.Repository;
using Threax.AspNetCore.Halcyon.Client.OpenIdConnect;
using Threax.Home;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add the home client set as a repository.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">The configure callback.</param>
        /// <returns></returns>
        public static IServiceCollection AddHomeClientRepository(this IServiceCollection services, Action<HomeClientOptions> configure)
        {
            var options = new HomeClientOptions();
            configure?.Invoke(options);

            var sharedCredentials = new SharedClientCredentials();
            options.GetSharedClientCredentials?.Invoke(sharedCredentials);

            services.TryAddSingleton<IHttpClientFactory, DefaultHttpClientFactory>();

            services.TryAddSingleton<IHomeClientManager>(s =>
            {
                var manager = new HomeClientManager();
                if (options.Clients != null)
                {
                    foreach (var client in options.Clients)
                    {
                        var creds = client.Value.ClientCredentials;
                        sharedCredentials.MergeWith(creds);
                        var clientCredsFactory = new ClientCredentialsAccessTokenFactory<EntryPointInjector>(creds, new BearerHttpClientFactory<EntryPointInjector>(s.GetRequiredService<IHttpClientFactory>()));
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
