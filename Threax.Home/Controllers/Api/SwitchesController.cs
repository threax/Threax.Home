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

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class SwitchesController : Controller
    {
        private ISwitchRepository repo;

        public SwitchesController(ISwitchRepository repo)
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
        [HalRel(nameof(AddHueSwitches))]
        public async Task AddHueSwitches([FromServices] IHueSwitchRepository<SwitchInput, SwitchInput> hueSwitchRepository)
        {
            foreach(var item in await hueSwitchRepository.List())
            {
                try
                {
                    //Kind of brute force
                    await repo.Add(item);
                }
                catch (Exception){ }
            }
        }

        [HttpGet("{SwitchId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Switch> Get(Guid switchId, [FromServices] IHueSwitchRepository<SwitchInput, SwitchInput> hueSwitchRepository)
        {
            var cachedSwitch = await repo.Get(switchId);
            var liveSwitch = await hueSwitchRepository.Get(cachedSwitch.Bridge, cachedSwitch.Id);
            return await repo.Update(switchId, liveSwitch);
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
        public async Task<Switch> Update(Guid switchId, [FromBody]SwitchInput @switch, [FromServices] IHueSwitchRepository<SwitchInput, Switch> hueSwitchRepository)
        {
            var cachedSwitch = await repo.Update(switchId, @switch);
            await hueSwitchRepository.Set(@switch);
            var liveSwitch = await hueSwitchRepository.Get(cachedSwitch.Bridge, cachedSwitch.Id);
            liveSwitch.SwitchId = switchId;
            return liveSwitch;
        }

        //[HttpDelete("{SwitchId}")]
        //[HalRel(CrudRels.Delete)]
        //public async Task Delete(Guid switchId)
        //{
        //    await repo.Delete(switchId);
        //}
    }
}