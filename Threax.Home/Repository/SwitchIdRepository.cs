using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Database;

namespace Threax.Home.Repository
{
    public class SwitchIdLookup : IEquatable<SwitchIdLookup>
    {
        public SwitchIdLookup(String subsystem, String bridge, String id)
        {
            this.Subsystem = subsystem;
            this.Bridge = bridge;
            this.Id = id;
        }

        public String Subsystem { get; set; }

        public String Bridge { get; set; }

        public String Id { get; set; }

        public bool Equals(SwitchIdLookup other)
        {
            return this.Subsystem == other.Subsystem
                && this.Bridge == other.Bridge
                && this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return $"s:{Subsystem}|b{Bridge}|i{Id}".GetHashCode();
        }
    }

    public class SwitchIdRepository : ISwitchIdRepository
    {
        private AppDbContext dbContext;
        private List<SwitchEntity> loadedIds = new List<SwitchEntity>();

        public SwitchIdRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public SwitchEntity GetLoaded(SwitchIdLookup lookup)
        {
            lookup = Normalize(lookup);
            return loadedIds.Where(i => i.Bridge == lookup.Bridge && i.Subsystem == lookup.Subsystem && i.Id == lookup.Id).First();
        }

        public async Task<SwitchEntity> Load(Guid id)
        {
            //Check loaded first
            var classEntity = loadedIds.Where(i => i.SwitchId == id).FirstOrDefault();
            if (classEntity == null)
            {

                classEntity = await dbContext.Switches.Where(i => i.SwitchId == id).FirstAsync();
                loadedIds.Add(classEntity);
            }
            return classEntity;
        }

        public async Task Load(IEnumerable<SwitchIdLookup> lookups)
        {
            var itemList = lookups.Select(i => Normalize(i)).Distinct().ToList();
            var itemsNotLoaded = itemList.Where(o => !loadedIds.Any(i => i.Bridge == o.Bridge && i.Subsystem == o.Subsystem && i.Id == o.Id)).ToList();

            if (itemsNotLoaded.Count == 0)
            {
                //Finished if all items are already loaded.
                return;
            }

            //Load missing items from db
            var entities = await dbContext.Switches.Where(o => itemsNotLoaded.Any(i => i.Bridge == o.Bridge && i.Subsystem == o.Subsystem && i.Id == o.Id)).ToListAsync();

            //Find missing entites, save new ones one at a time, to take advantage of using the index for synchronization
            foreach (var lookup in itemsNotLoaded)
            {
                var entity = entities.FirstOrDefault(i => i.Bridge == lookup.Bridge && i.Subsystem == lookup.Subsystem && i.Id == lookup.Id);

                if (entity == null)
                {
                    entity = new SwitchEntity()
                    {
                        Bridge = lookup.Bridge,
                        Subsystem = lookup.Subsystem,
                        Id = lookup.Id
                    };
                    dbContext.Switches.Add(entity);

                    try
                    {
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        //An error here probably just means that the id was already generated, try one last time to return it.
                        entity = await dbContext.Switches.Where(i => i.Bridge == lookup.Bridge && i.Subsystem == lookup.Subsystem && i.Id == lookup.Id).FirstOrDefaultAsync();
                        if (entity == null)
                        {
                            throw;
                        }
                    }
                }
                loadedIds.Add(entity);
            }
        }

        public Task Load(SwitchIdLookup lookup)
        {
            return Load(new SwitchIdLookup[] { lookup });
        }

        private static SwitchIdLookup Normalize(SwitchIdLookup lookup)
        {
            return lookup;
        }
    }
}
