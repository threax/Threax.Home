using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Database;
using Threax.Home.InputModels;
using Threax.Home.Mappers;
using Threax.Home.ViewModels;

namespace Threax.Home.Repository
{
    public partial class SensorRepository : ISensorRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public SensorRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SensorCollection> List(SensorQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var resultQuery = dbQuery.Select(i => mapper.MapSensor(i, new Sensor()));
            var results = await resultQuery.ToListAsync();

            return new SensorCollection(query, total, results);
        }

        public async Task<Sensor> Get(Guid sensorId)
        {
            var entity = await this.Entity(sensorId);
            return mapper.MapSensor(entity, new Sensor());
        }

        public async Task<Sensor> Add(SensorInput sensor)
        {
            var entity = mapper.MapSensor(sensor, new SensorEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapSensor(entity, new Sensor());
        }

        public async Task AddMissing(IEnumerable<SensorInput> sensors)
        {
            var existing = await dbContext.Sensors.ToListAsync();

            var toAdd = sensors.Where(o => !existing.Any(i => o.Subsystem == i.Subsystem && o.Bridge == i.Bridge && o.Id == i.Id));
            await AddRange(toAdd);
        }

        public async Task<Sensor> Update(Guid sensorId, SensorInput sensor)
        {
            var entity = await this.Entity(sensorId);
            if (entity != null)
            {
                var oldName = entity.Name;
                mapper.MapSensor(sensor, entity);
                entity.Name = oldName;
                await SaveChanges();
                return mapper.MapSensor(entity, new Sensor());
            }
            throw new KeyNotFoundException($"Cannot find sensor {sensorId.ToString()}");
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

        public virtual async Task<bool> HasSensors()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<SensorInput> sensors)
        {
            var entities = sensors.Select(i => mapper.MapSensor(i, new SensorEntity()));
            this.dbContext.Sensors.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<SensorEntity> Entities
        {
            get
            {
                return dbContext.Sensors;
            }
        }

        private Task<SensorEntity> Entity(Guid sensorId)
        {
            return Entities.Where(i => i.SensorId == sensorId).FirstOrDefaultAsync();
        }
    }
}