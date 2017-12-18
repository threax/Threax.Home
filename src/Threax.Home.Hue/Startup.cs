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
using Threax.Home.Hue.Services;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Hue.Controllers;

namespace Threax.Home.Hue
{
    class Startup
    {
        private bool isDev;
        private AppConfig appConfig = new AppConfig();
        private ExceptionFilterOptions exceptionOptions = new ExceptionFilterOptions();
        new Dictionary<String, SyncedHueClient> bridges = new Dictionary<String, SyncedHueClient>();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationBinder.Bind(Configuration.GetSection("AppConfig"), appConfig);
            ConfigurationBinder.Bind(Configuration.GetSection("Exception"), exceptionOptions);
            ConfigurationBinder.Bind(Configuration.GetSection("Bridges"), bridges);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var halOptions = new HalcyonConventionOptions()
            {
                BaseUrl = appConfig.BaseUrl,
                HalDocEndpointInfo = new HalDocEndpointInfo(typeof(EndpointDocController))
            };

            services.AddConventionalHalcyon(halOptions);

            services.AddSingleton(s =>
            {
                return new HueClientManager(bridges);
            });

            services.AddExceptionErrorFilters(exceptionOptions);

            services.AddMvc(o =>
            {
                o.UseExceptionErrorFilters();
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
            if (isDev)
            {
                app.UseCors(c =>
                {
                    c.AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowAnyOrigin()
                     .AllowCredentials();
                });
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
