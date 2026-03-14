using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.ReflectedServices;

namespace Threax.Home.Repository.Config
{
    public partial class SensorRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<ISensorRepository, SensorRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}