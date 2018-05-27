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
        private IHueSwitchRepository<SwitchInput, Switch> hueSwitchRepository;

        public SwitchesController(ISwitchRepository repo, IHueSwitchRepository<SwitchInput, Switch> hueSwitchRepository)
        {
            this.repo = repo;
            this.hueSwitchRepository = hueSwitchRepository;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<SwitchCollection> List([FromQuery] SwitchQuery query)
        {
            //return await repo.List(query);
            var items = await hueSwitchRepository.List();
            var count = items.Count();
            return new SwitchCollection(query, items.Count(), items.Skip(query.SkipTo(count)).Take(query.Limit));
        }

        [HttpGet("{SwitchId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Switch> Get(Guid switchId)
        {
            return await repo.Get(switchId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new @switch")]
        public async Task<Switch> Add([FromBody]SwitchInput @switch)
        {
            return await repo.Add(@switch);
        }

        [HttpPut("{SwitchId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update @switch")]
        public async Task<Switch> Update(Guid switchId, [FromBody]SwitchInput @switch)
        {
            return await repo.Update(switchId, @switch);
        }

        [HttpDelete("{SwitchId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid switchId)
        {
            await repo.Delete(switchId);
        }
    }
}