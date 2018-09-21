using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Threax.Home.Repository;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ViewModels;
using Threax.Home.InputModels;
using Threax.Home.Models;
using Microsoft.AspNetCore.Authorization;
using Threax.Home.Core;

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class SensorsController : Controller
    {
        private Repository.ISensorRepository repo;

        public SensorsController(Repository.ISensorRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<SensorCollection> List([FromQuery] SensorQuery query)
        {
            return await repo.List(query);
        }

        [HttpPost("[action]")]
        [HalRel(nameof(AddNewSensors))]
        [Authorize(Roles = Roles.EditSensors)]
        public async Task AddNewSensors([FromServices] ISensorSubsystemManager<SensorInput> sensors)
        {
            var items = await sensors.List();
            await repo.AddMissing(items);
        }

        [HttpGet("{SensorId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Sensor> Get(Guid sensorId, [FromServices] ISensorSubsystemManager<SensorInput> sensors)
        {
            var cached = await repo.Get(sensorId);
            var live = await sensors.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(sensorId, live);
        }

        [HttpPut("{SensorId}")]
        [HalRel(CrudRels.Update)]
        [Authorize(Roles = Roles.EditSensors)]
        [AutoValidate("Cannot update sensor")]
        public async Task<Sensor> Update(Guid sensorId, [FromBody]SensorInput sensor)
        {
            return await repo.Update(sensorId, sensor);
        }

        //[HttpDelete("{SensorId}")]
        //[HalRel(CrudRels.Delete)]
        //public async Task Delete(Guid sensorId)
        //{
        //    await repo.Delete(sensorId);
        //}
    }
}