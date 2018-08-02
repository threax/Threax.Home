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
    public partial class ThermostatsController : Controller
    {
        private Repository.IThermostatRepository repo;

        public ThermostatsController(Repository.IThermostatRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ThermostatCollection> List([FromQuery] ThermostatQuery query)
        {
            return await repo.List(query);
        }

        [HttpPost("[action]")]
        [HalRel(nameof(AddNewThermostats))]
        public async Task AddNewThermostats([FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var items = await thermostats.List();
            await repo.AddMissing(items);
        }

        [HttpGet("{ThermostatId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Thermostat> Get(Guid thermostatId, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var cached = await repo.Get(thermostatId);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(thermostatId, live);
        }

        //[HttpPost]
        //[HalRel(CrudRels.Add)]
        //[AutoValidate("Cannot add new thermostat")]
        //public async Task<Thermostat> Add([FromBody]ThermostatInput thermostat)
        //{
        //    return await repo.Add(thermostat);
        //}

        [HttpPut("{ThermostatId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update thermostat")]
        public async Task<Thermostat> Update(Guid thermostatId, [FromBody]ThermostatInput thermostat, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var cached = await repo.Get(thermostatId);
            thermostat.Bridge = cached.Bridge;
            thermostat.Subsystem = cached.Subsystem;
            thermostat.Id = cached.Id;
            await thermostats.Set(thermostat);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(thermostatId, live);
        }

        //[HttpDelete("{ThermostatId}")]
        //[HalRel(CrudRels.Delete)]
        //public async Task Delete(Guid thermostatId)
        //{
        //    await repo.Delete(thermostatId);
        //}
    }
}