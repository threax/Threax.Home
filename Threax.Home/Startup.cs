﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Threax.Home.Controllers;
using Threax.Home.Controllers.Api;
using Threax.Home.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Threax.AspNetCore.BuiltInTools;
using Threax.AspNetCore.CorsManager;
using Threax.AspNetCore.Halcyon.ClientGen;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.IdServerAuth;
using Threax.Extensions.Configuration.SchemaBinder;
using Threax.AspNetCore.UserBuilder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Threax.Home
{
    public class Startup
    {
        //Replace the following values with your own values
        private IdServerAuthAppOptions authConfig = new IdServerAuthAppOptions()
        {
            Scope = "Threax.Home", //The name of the scope for api access
            DisplayName = "Threax.Home", //Change this to a pretty name for the client/resource
            ClientId = "Threax.Home", //Change this to a unique client id
            AdditionalScopes = new List<String>{ /*Additional scopes here "ScopeName", "Scope2Name", "etc"*/ }
        };
        //End user replace

        private AppConfig appConfig = new AppConfig();
        private ClientConfig clientConfig = new ClientConfig();
        private CorsManagerOptions corsOptions = new CorsManagerOptions();

        public Startup(IConfiguration configuration)
        {
            Configuration = new SchemaConfigurationBinder(configuration);
            Configuration.Bind("JwtAuth", authConfig);
            Configuration.Bind("AppConfig", appConfig);
            Configuration.Bind("ClientConfig", clientConfig);
            Configuration.Bind("Cors", corsOptions);
        }

        public SchemaConfigurationBinder Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Threax.AspNetCore.Docker.Certs.CertManager.LoadTrustedRoots(o => Configuration.Bind("CertManager", o));

            services.AddHue(o => Configuration.Bind("Hue", o));
            services.AddMfi(o => Configuration.Bind("Mfi", o));
            services.AddZWave(o => Configuration.Bind("ZWave", o));
            services.AddColorTouch(o => Configuration.Bind("ColorTouch", o));

            //Add the client side configuration object
            services.AddClientConfig(clientConfig, o =>
            {
                o.RouteArgsToClear = new List<string>() { "inPagePath" };
            });

            services.AddAssetBundle(o =>
            {
                o.UseBundles = appConfig.UseAssetBundles;
            });

            ApiExplorerController.Allow = appConfig.AllowApiExplorer;

            services.AddTimeTracking();

            services.AddHalClientGen(new HalClientGenOptions()
            {
                SourceAssemblies = new Assembly[] { this.GetType().GetTypeInfo().Assembly },
                CSharp = new CSharpOptions()
                {
                    Namespace = "Threax.Home.Client"
                }
            });

            services.AddConventionalIdServerAuthentication(o =>
            {
                o.AppOptions = authConfig;
                o.CookiePath = appConfig.PathBase;
                o.AccessDeniedPath = "/Account/AccessDenied";
                o.ConfigureIdServerMetadataJwtOptions = jwtOpt =>
                {
                    jwtOpt.Audience = "Threax.IdServer";
                };
            });

            services.UseAppDatabase(appConfig.ConnectionString);

            var halOptions = new HalcyonConventionOptions()
            {
                BaseUrl = appConfig.BaseUrl,
                HalDocEndpointInfo = new HalDocEndpointInfo(typeof(EndpointDocController))
            };

            services.AddConventionalHalcyon(halOptions);

            services.AddExceptionErrorFilters(new ExceptionFilterOptions()
            {
                DetailedErrors = appConfig.DetailedErrors
            });

            // Add framework services.
            services.AddMvc(o =>
            {
                o.UseExceptionErrorFilters();
                o.UseConventionalHalcyon(halOptions);
            })
            .AddJsonOptions(o =>
            {
                o.SerializerSettings.SetToHalcyonDefault();
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddConventionalIdServerMvc();

            services.AddScoped<IToolRunner>(s =>
            {
                return new ToolRunner()
                .AddTool("migrate", new ToolCommand("Migrate database to newest version. Run anytime new migrations have been added.", async a =>
                {
                    await a.Migrate();
                }))
                .AddTool("seed", new ToolCommand("Seed database data. Only needed for an empty database.", async a =>
                {
                    await a.Seed();
                }))
                .AddTool("addadmin", new ToolCommand("Add given guids as a user with permissions to all roles in the database.", async a =>
                {
                    await a.AddAdmin();
                }))
                .AddTool("updateConfigSchema", new ToolCommand("Update the schema file for this application's configuration.", async a =>
                {
                    var json = await Configuration.CreateSchema();
                    await File.WriteAllTextAsync("appsettings.schema.json", json);
                }))
                .UseClientGenTools();
            });

            services.AddUserBuilderForUserWhitelistWithRoles();

            services.SetupSwitches();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
                //Can add ForwardedHeaders.XForwardedFor later, but tricky with container proxy since we don't know its ip
                //This is enough to get https detection working again, however.
                //https://github.com/aspnet/Docs/issues/2384
            });

            app.UseUrlFix(o =>
            {
                o.CorrectPathBase = appConfig.PathBase;
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseCorsManager(corsOptions, loggerFactory);

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "root",
                    template: "{action=Index}/{*inPagePath}",
                    defaults: new { controller = "Home" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{*inPagePath}");
            });
        }
    }
}