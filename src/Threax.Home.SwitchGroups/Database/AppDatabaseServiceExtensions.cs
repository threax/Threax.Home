using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.SwitchGroups.Database
{
    /// <summary>
    /// This class sets up the api's database and type mappings.
    /// </summary>
    public static class AppDatabaseServiceExtensions
    {
        /// <summary>
        /// Setup the app's database.
        /// </summary>
        /// <param name="services">The services object that is extended.</param>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection UseAppDatabase(this IServiceCollection services, string connectionString)
        {
            //Add the database
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //Setup the mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                
            });
            services.AddScoped<IMapper>(i => mapperConfig.CreateMapper());

            return services;
        }
    }
}
