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
    public partial class AppCommandRepository : IAppCommandRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public AppCommandRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppCommandCollection> List(AppCommandQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new AppCommandCollection(query, total, results.Select(i => mapper.MapButtonState(i, new AppCommand())));
        }

        public async Task<AppCommand> Get(Guid buttonId)
        {
            var entity = await this.Entity(buttonId);
            return mapper.MapButtonState(entity, new AppCommand());
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