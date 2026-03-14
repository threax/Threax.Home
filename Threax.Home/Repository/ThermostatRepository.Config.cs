using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.ReflectedServices;

namespace Threax.Home.Repository.Config
{
    public partial class ThermostatRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IThermostatRepository, ThermostatRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}