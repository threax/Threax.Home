using Microsoft.EntityFrameworkCore;

namespace Threax.Home.Database
{
    public partial class AppDbContext
    {
        public DbSet<ThermostatSettingEntity> ThermostatSettings { get; set; }
    }
}
