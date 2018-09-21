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
using Threax.Home.Database;

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
        public async Task AddNewSwitches()
        {
            await repo.AddNewSwitches();
        }

        [HttpGet("{SwitchId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Switch> Get(Guid switchId)
        {
            return await repo.Get(switchId);
        }

        [HttpPut("Set/{SwitchId}")]
        [HalRel(nameof(Set))]
        [AutoValidate("Cannot update switch")]
        public async Task<Switch> Set(Guid switchId, [FromBody]SetSwitchInput @switch)
        {
            return await repo.Set(switchId, @switch);
        }

        [HttpPut("{SwitchId}")]
        [HalRel(CrudRels.Update)]
        [Authorize(Roles = Roles.EditSwitches)]
        [AutoValidate("Cannot update switch")]
        public async Task<Switch> Update(Guid switchId, [FromBody]SwitchInput @switch)
        {
            return await repo.Update(switchId, @switch);
        }

        [HttpDelete("{SwitchId}")]
        [HalRel(CrudRels.Delete)]
        [Authorize(Roles = Roles.EditSwitches)]
        public async Task Delete(Guid switchId)
        {
            await repo.Delete(switchId);
        }
    }
}