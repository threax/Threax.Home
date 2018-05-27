using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Repository
{
    public partial class SwitchRepository : ISwitchRepository
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public SwitchRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SwitchCollection> List(SwitchQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var resultQuery = dbQuery.Select(i => mapper.Map<Switch>(i));
            var results = await resultQuery.ToListAsync();

            return new SwitchCollection(query, total, results);
        }

        public async Task<Switch> Get(Guid switchId)
        {
            var entity = await this.Entity(switchId);
            return mapper.Map<Switch>(entity);
        }

        public async Task<Switch> Add(SwitchInput @switch)
        {
            var entity = mapper.Map<SwitchEntity>(@switch);
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.Map<Switch>(entity);
        }

        public async Task<Switch> Update(Guid switchId, SwitchInput @switch)
        {
            var entity = await this.Entity(switchId);
            if (entity != null)
            {
                mapper.Map(@switch, entity);
                await SaveChanges();
                return mapper.Map<Switch>(entity);
            }
            throw new KeyNotFoundException($"Cannot find @switch {switchId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasSwitches()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<SwitchInput> switches)
        {
            var entities = switches.Select(i => mapper.Map<SwitchEntity>(i));
            this.dbContext.Switches.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<SwitchEntity> Entities
        {
            get
            {
                return dbContext.Switches;
            }
        }

        private Task<SwitchEntity> Entity(Guid switchId)
        {
            return Entities.Where(i => i.SwitchId == switchId).FirstOrDefaultAsync();
        }
    }
}