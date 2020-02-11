using AppTemplateClient;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Threax.AspNetCore.Halcyon.Client;
using Threax.Home.Client;
using Threax.Home.Client.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add a EntryPointInjector from the home library.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IHalcyonClientSetup<EntryPointInjector> AddHomeClient(this IServiceCollection services, Action<HomeClientConfig> configure)
        {
            var client = new HomeClientConfig();
            configure.Invoke(client);

            services.TryAddScoped<EntryPointInjector>(s =>
            {
                return new EntryPointInjector(client.ServiceUrl, s.GetRequiredService<IHttpClientFactory<EntryPointInjector>>());
            });

            return new HalcyonClientSetup<EntryPointInjector>(services);
        }
    }
}
