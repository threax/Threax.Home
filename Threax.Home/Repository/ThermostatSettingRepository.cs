using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;
using Threax.Home.Models;
using Threax.Home.Mappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.Home.Repository
{
    public partial class ThermostatSettingRepository : IThermostatSettingRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public ThermostatSettingRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ThermostatSettingCollection> List(ThermostatSettingQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new ThermostatSettingCollection(query, total, results.Select(i => mapper.MapThermostatSetting(i, new ThermostatSetting())));
        }

        public async Task<ThermostatSetting> Get(Guid thermostatSettingId)
        {
            var entity = await this.Entity(thermostatSettingId);
            return mapper.MapThermostatSetting(entity, new ThermostatSetting());
        }

        public async Task<ThermostatSetting> Add(ThermostatSettingInput thermostatSetting)
        {
            var entity = mapper.MapThermostatSetting(thermostatSetting, new ThermostatSettingEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapThermostatSetting(entity, new ThermostatSetting());
        }

        public async Task<ThermostatSetting> Update(Guid thermostatSettingId, ThermostatSettingInput thermostatSetting)
        {
            var entity = await this.Entity(thermostatSettingId);
            if (entity != null)
            {
                mapper.MapThermostatSetting(thermostatSetting, entity);
                await SaveChanges();
                return mapper.MapThermostatSetting(entity, new ThermostatSetting());
            }
            throw new KeyNotFoundException($"Cannot find thermostatSetting {thermostatSettingId.ToString()}");
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

        public virtual async Task<bool> HasThermostatSettings()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<ThermostatSettingInput> thermostatSettings)
        {
            var entities = thermostatSettings.Select(i => mapper.MapThermostatSetting(i, new ThermostatSettingEntity()));
            this.dbContext.ThermostatSettings.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<ThermostatSettingEntity> Entities
        {
            get
            {
                return dbContext.ThermostatSettings;
            }
        }

        private Task<ThermostatSettingEntity> Entity(Guid thermostatSettingId)
        {
            return Entities.Where(i => i.ThermostatSettingId == thermostatSettingId).FirstOrDefaultAsync();
        }
    }
}