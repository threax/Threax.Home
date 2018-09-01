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
    public partial class ButtonRepository : IButtonRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public ButtonRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ButtonCollection> List(ButtonQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new ButtonCollection(query, total, results.Select(i => mapper.MapButton(i, new Button())));
        }

        public async Task<Button> Get(Guid buttonId)
        {
            var entity = await this.Entity(buttonId);
            return mapper.MapButton(entity, new Button());
        }

        public async Task<Button> Add(ButtonInput button)
        {
            var entity = mapper.MapButton(button, new ButtonEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapButton(entity, new Button());
        }

        public async Task<Button> Update(Guid buttonId, ButtonInput button)
        {
            var entity = await this.Entity(buttonId);
            if (entity != null)
            {
                mapper.MapButton(button, entity);
                await SaveChanges();
                return mapper.MapButton(entity, new Button());
            }
            throw new KeyNotFoundException($"Cannot find button {buttonId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                dbContext.Buttons.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasButtons()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<ButtonInput> buttons)
        {
            var entities = buttons.Select(i => mapper.MapButton(i, new ButtonEntity()));
            this.dbContext.Buttons.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private IQueryable<ButtonEntity> Entities
        {
            get
            {
                return dbContext.Buttons.Include(i => i.ButtonStates).ThenInclude(i => i.SwitchSettings);
            }
        }

        private Task<ButtonEntity> Entity(Guid buttonId)
        {
            return Entities.Where(i => i.ButtonId == buttonId).FirstOrDefaultAsync();
        }
    }
}