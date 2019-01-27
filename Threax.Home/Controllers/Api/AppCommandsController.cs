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
    public partial class AppCommandsController : Controller
    {
        private IAppCommandRepository repo;

        public AppCommandsController(IAppCommandRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<AppCommandCollection> List([FromQuery] AppCommandQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{ButtonStateId}")]
        [HalRel(CrudRels.Get)]
        public async Task<AppCommand> Get(Guid buttonStateId)
        {
            return await repo.Get(buttonStateId);
        }
    }
}
