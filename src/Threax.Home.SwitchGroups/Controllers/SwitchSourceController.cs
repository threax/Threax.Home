using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.SwitchGroups.Database;

namespace Threax.Home.SwitchGroups.Controllers
{
    [Route("[controller]/[action]")]
    public class SwitchSourceController : Controller
    {
        private AppDbContext dbContext;

        public SwitchSourceController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SwitchSource>> List()
        {
            return await dbContext.SwitchSources.ToListAsync();
        }

        public async Task<SwitchSource> Get([FromQuery] int id)
        {
            return (await dbContext.SwitchSources.Where(i => i.SwitchSourceId == id).ToListAsync()).First();
        }

        public async Task Create([FromBody] SwitchSource source)
        {
            source.SwitchSourceId = 0;
            dbContext.SwitchSources.Add(source);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update([FromBody] SwitchSource source)
        {
            dbContext.SwitchSources.Update(source);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete([FromQuery] int id)
        {
            dbContext.SwitchSources.RemoveRange(await Get(id));
            await dbContext.SaveChangesAsync();
        }
    }
}
