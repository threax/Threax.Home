using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.AspNetCore.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.Home.Repository;
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