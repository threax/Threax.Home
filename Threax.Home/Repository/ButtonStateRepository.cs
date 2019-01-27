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
using Threax.Home.Core;

namespace Threax.Home.Repository
{
    public partial class ButtonStateRepository : IButtonStateRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public ButtonStateRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ButtonStateCollection> List(ButtonStateQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new ButtonStateCollection(query, total, results.Select(i => mapper.MapButtonState(i, new ButtonState())));
        }

        public async Task<ButtonState> Get(Guid buttonId)
        {
            var entity = await this.Entity(buttonId);
            return mapper.MapButtonState(entity, new ButtonState());
        }

        public async Task<Button> Add(ButtonInput button)
        {
            var entity = mapper.MapButton(button, new ButtonEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapButton(entity, new Button());
        }

        public virtual async Task AddRange(IEnumerable<ButtonInput> buttons)
        {
            var entities = buttons.Select(i => mapper.MapButton(i, new ButtonEntity()));
            this.dbContext.Buttons.AddRange(entities);
            await SaveChanges();
        }

        public async Task<Button> Apply(Guid buttonStateId, ISwitchSubsystemManager<SwitchEntity, SwitchEntity> switchRepo)
        {
            var buttonstate = await dbContext.ButtonStates.Include(i => i.SwitchSettings).Where(i => i.ButtonStateId == buttonStateId).FirstAsync();
            var switchIds = buttonstate.SwitchSettings.Select(i => i.SwitchId);
            var switches = await dbContext.Switches.Where(i => switchIds.Contains(i.SwitchId)).ToListAsync();
            var switchInputs = switches.Select(i =>
            {
                var setting = buttonstate.SwitchSettings.Where(j => j.SwitchId == i.SwitchId).First();

                //Update the switch status on the entity
                i.Value = setting.Value;
                i.HexColor = setting.HexColor;
                i.Brightness = (byte?)setting.Brightness; //TODO: Fix this type

                return i;
            });

            foreach (var item in switchInputs)
            {
                await switchRepo.Set(item);
            }

            //Save switch status updates
            await dbContext.SaveChangesAsync();

            //Reload button info
            var buttonState = await dbContext.ButtonStates.Include(i => i.Button).Where(i => i.ButtonStateId == buttonStateId).FirstAsync();
            return mapper.MapButton(buttonState.Button, new Button());
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private IQueryable<ButtonStateEntity> Entities
        {
            get
            {
                return dbContext.ButtonStates.Include(i => i.Button).Include(i => i.SwitchSettings).ThenInclude(i => i.Switch);
            }
        }

        private Task<ButtonStateEntity> Entity(Guid buttonId)
        {
            return Entities.Where(i => i.ButtonId == buttonId).FirstOrDefaultAsync();
        }
    }
}