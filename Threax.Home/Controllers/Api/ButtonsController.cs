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
using Threax.Home.Database;

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class ButtonsController : Controller
    {
        private IButtonRepository repo;

        public ButtonsController(IButtonRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ButtonCollection> List([FromQuery] ButtonQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{ButtonId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Button> Get(Guid buttonId)
        {
            return await repo.Get(buttonId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new button")]
        [Authorize(Roles = Roles.EditButtons)]
        public async Task<Button> Add([FromBody]ButtonInput button)
        {
            return await repo.Add(button);
        }

        [HttpPut("{ButtonId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update button")]
        [Authorize(Roles = Roles.EditButtons)]
        public async Task<Button> Update(Guid buttonId, [FromBody]ButtonInput button)
        {
            return await repo.Update(buttonId, button);
        }

        [HttpDelete("{ButtonId}")]
        [HalRel(CrudRels.Delete)]
        [Authorize(Roles = Roles.EditButtons)]
        public async Task Delete(Guid buttonId)
        {
            await repo.Delete(buttonId);
        }

        [HttpPut("[action]")]
        [HalRel(nameof(Apply))]
        public async Task<Button> Apply([FromBody] ApplyButtonInput input, [FromServices] ISwitchSubsystemManager<SwitchEntity, SwitchEntity> switchRepo)
        {
            return await repo.Apply(input, switchRepo);
        }
    }
}