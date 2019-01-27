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

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class ButtonStatesController : Controller
    {
        private IButtonRepository repo;

        public ButtonStatesController(IButtonRepository repo)
        {
            this.repo = repo;
        }

        [HttpPut("[action]/{ButtonStateId}")]
        [HalRel(nameof(Apply))]
        public async Task<Button> Apply(Guid buttonStateId, [FromServices] ISwitchSubsystemManager<SwitchEntity, SwitchEntity> switchRepo)
        {
            return await repo.Apply(buttonStateId, switchRepo);
        }
    }
}
