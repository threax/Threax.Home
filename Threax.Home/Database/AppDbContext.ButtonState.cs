using Microsoft.EntityFrameworkCore;

namespace Threax.Home.Database
{
    public partial class AppDbContext
    {
        public DbSet<ButtonStateEntity> ButtonStates { get; set; }
    }
}
