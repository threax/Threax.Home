using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.ViewModels;
using Threax.Home.Core;
using Threax.Home.Database;
using Threax.Home.Repository;
using Threax.Home.InputModels;

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class ButtonStatesController : Controller
    {
        private IButtonStateRepository repo;

        public ButtonStatesController(IButtonStateRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ButtonStateCollection> List([FromQuery] ButtonStateQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{ButtonStateId}")]
        [HalRel(CrudRels.Get)]
        public async Task<ButtonState> Get(Guid buttonStateId)
        {
            return await repo.Get(buttonStateId);
        }

        [HttpPut("[action]/{ButtonStateId}")]
        [HalRel(nameof(Apply))]
        public async Task<Button> Apply(Guid buttonStateId, [FromServices] ISwitchSubsystemManager<SwitchEntity, SwitchEntity> switchRepo)
        {
            return await repo.Apply(buttonStateId, switchRepo);
        }
    }
}
