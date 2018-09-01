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
    public partial class ButtonSettingRepository : IButtonSettingRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public ButtonSettingRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ButtonSettingCollection> List(ButtonSettingQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new ButtonSettingCollection(query, total, results.Select(i => mapper.MapButtonSetting(i, new ButtonSetting())));
        }

        public async Task<ButtonSetting> Get(Guid buttonSettingId)
        {
            var entity = await this.Entity(buttonSettingId);
            return mapper.MapButtonSetting(entity, new ButtonSetting());
        }

        public async Task<ButtonSetting> Add(ButtonSettingInput buttonSetting)
        {
            var entity = mapper.MapButtonSetting(buttonSetting, new ButtonSettingEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapButtonSetting(entity, new ButtonSetting());
        }

        public async Task<ButtonSetting> Update(Guid buttonSettingId, ButtonSettingInput buttonSetting)
        {
            var entity = await this.Entity(buttonSettingId);
            if (entity != null)
            {
                mapper.MapButtonSetting(buttonSetting, entity);
                await SaveChanges();
                return mapper.MapButtonSetting(entity, new ButtonSetting());
            }
            throw new KeyNotFoundException($"Cannot find buttonSetting {buttonSettingId.ToString()}");
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

        public virtual async Task<bool> HasButtonSettings()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<ButtonSettingInput> buttonSettings)
        {
            var entities = buttonSettings.Select(i => mapper.MapButtonSetting(i, new ButtonSettingEntity()));
            this.dbContext.ButtonSettings.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<ButtonSettingEntity> Entities
        {
            get
            {
                return dbContext.ButtonSettings;
            }
        }

        private Task<ButtonSettingEntity> Entity(Guid buttonSettingId)
        {
            return Entities.Where(i => i.ButtonSettingId == buttonSettingId).FirstOrDefaultAsync();
        }
    }
}