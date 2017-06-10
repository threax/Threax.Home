using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using ZWave;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ZWave.Controllers;

namespace Threax.Home.ZWave
{
    class Startup
    {
        private bool isDev;
        private AppConfig appConfig = new AppConfig();

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            isDev = env.IsEnvironment("Development");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            ConfigurationBinder.Bind(Configuration.GetSection("AppConfig"), appConfig);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var halOptions = new HalcyonConventionOptions()
            {
                BaseUrl = appConfig.BaseUrl,
                HalDocEndpointInfo = new HalDocEndpointInfo(typeof(EndpointDocController))
            };

            services.AddConventionalHalcyon(halOptions);

            services.AddSingleton<ZWaveController>(s =>
            {
                var controller = new ZWaveController(appConfig.ComPort);
                controller.Open();
                return controller;
                //Close is not called, but even following proper patterns it wasn't called, figure this out later.
            });

            services.AddMvc(o =>
            {
                o.UseExceptionErrorFilters(isDev);
                o.UseConventionalHalcyon(halOptions);
            })
            .AddJsonOptions(o =>
            {
                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                o.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
