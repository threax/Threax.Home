using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Threax.Home.SwitchGroups.Database
{
    /// <summary>
    /// The database context for the switch groups.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<SwitchSource> SwitchSources { get; set; }
    }
}
