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
using Threax.Home.Hue.Repository;
using Threax.Home.Core;

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class SwitchesController : Controller
    {
        private Repository.ISwitchRepository repo;

        public SwitchesController(Repository.ISwitchRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<SwitchCollection> List([FromQuery] SwitchQuery query)
        {
            return await repo.List(query);
        }

        [HttpPost("[action]")]
        [HalRel(nameof(AddNewSwitches))]
        public async Task AddNewSwitches([FromServices] ISwitchSubsystemManager<SwitchInput, SwitchInput> switchRepo)
        {
            var items = await switchRepo.List();
            await repo.AddMissing(items);
        }

        [HttpGet("{SwitchId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Switch> Get(Guid switchId, [FromServices] ISwitchSubsystemManager<SwitchInput, SwitchInput> switchRepo)
        {
            var cached = await repo.Get(switchId);
            var live = await switchRepo.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(switchId, live);
        }

        //[HttpPost]
        //[HalRel(CrudRels.Add)]
        //[AutoValidate("Cannot add new @switch")]
        //public async Task<Switch> Add([FromBody]SwitchInput @switch)
        //{
        //    return await repo.Add(@switch);
        //}

        [HttpPut("{SwitchId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update @switch")]
        public async Task<Switch> Update(Guid switchId, [FromBody]SwitchInput @switch, [FromServices] ISwitchSubsystemManager<SwitchInput, SwitchInput> switchRepo)
        {
            var cachedSwitch = await repo.Get(switchId);
            @switch.Bridge = cachedSwitch.Bridge;
            @switch.Subsystem = cachedSwitch.Subsystem;
            @switch.Id = cachedSwitch.Id;
            await switchRepo.Set(@switch);
            var liveSwitch = await switchRepo.Get(cachedSwitch.Subsystem, cachedSwitch.Bridge, cachedSwitch.Id);
            return await repo.Update(switchId, liveSwitch);
        }

        //[HttpDelete("{SwitchId}")]
        //[HalRel(CrudRels.Delete)]
        //public async Task Delete(Guid switchId)
        //{
        //    await repo.Delete(switchId);
        //}
    }
}