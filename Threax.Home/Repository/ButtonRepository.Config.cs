using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.ReflectedServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.Home.Repository;

namespace Threax.Home.Repository.Config
{
    public partial class ButtonRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IButtonRepository, ButtonRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}