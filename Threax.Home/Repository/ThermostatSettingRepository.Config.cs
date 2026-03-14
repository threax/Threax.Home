using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.ReflectedServices;

namespace Threax.Home.Repository.Config
{
    public partial class ThermostatSettingRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IThermostatSettingRepository, ThermostatSettingRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}