using Microsoft.EntityFrameworkCore;

namespace Threax.Home.Database
{
    public partial class AppDbContext
    {
        public DbSet<ValueEntity> Values { get; set; }
    }
}
