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
using Threax.Home.Core;

namespace Threax.Home.Repository
{
    public partial class ThermostatRepository : IThermostatRepository
    {
        private AppDbContext dbContext;
        private IMapper mapper;

        public ThermostatRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ThermostatCollection> List(ThermostatQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var resultQuery = dbQuery.Select(i => mapper.Map<Thermostat>(i));
            var results = await resultQuery.ToListAsync();

            return new ThermostatCollection(query, total, results);
        }

        public async Task<Thermostat> Get(Guid thermostatId)
        {
            var entity = await this.Entity(thermostatId);
            return mapper.Map<Thermostat>(entity);
        }

        public async Task<Thermostat> Add(ThermostatInput thermostat)
        {
            var entity = mapper.Map<ThermostatEntity>(thermostat);
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.Map<Thermostat>(entity);
        }

        public async Task<Thermostat> Update(Guid thermostatId, ThermostatInput thermostat)
        {
            var entity = await this.Entity(thermostatId);
            if (entity != null)
            {
                mapper.Map(thermostat, entity);
                await SaveChanges();
                return mapper.Map<Thermostat>(entity);
            }
            throw new KeyNotFoundException($"Cannot find thermostat {thermostatId.ToString()}");
        }

        public async Task<Thermostat> Update(Guid thermostatId, Thermostat thermostat)
        {
            var entity = await this.Entity(thermostatId);
            if (entity != null)
            {
                mapper.Map(thermostat, entity);
                await SaveChanges();
                return mapper.Map<Thermostat>(entity);
            }
            throw new KeyNotFoundException($"Cannot find thermostat {thermostatId.ToString()}");
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

        public virtual async Task<bool> HasThermostats()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<ThermostatInput> thermostats)
        {
            var entities = thermostats.Select(i => mapper.Map<ThermostatEntity>(i));
            this.dbContext.Thermostats.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<ThermostatEntity> Entities
        {
            get
            {
                return dbContext.Thermostats;
            }
        }

        private Task<ThermostatEntity> Entity(Guid thermostatId)
        {
            return Entities.Where(i => i.ThermostatId == thermostatId).FirstOrDefaultAsync();
        }

        public async Task AddMissing(IEnumerable<Thermostat> items)
        {
            var existing = await dbContext.Thermostats.ToListAsync();

            var toAdd = items.Where(o => !existing.Any(i => o.Subsystem == i.Subsystem && o.Bridge == i.Bridge && o.Id == i.Id));
            await AddRange(toAdd.Select(i => mapper.Map<ThermostatInput>(i)));
        }
    }
}