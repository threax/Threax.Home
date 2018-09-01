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

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class ButtonSettingsController : Controller
    {
        private IButtonSettingRepository repo;

        public ButtonSettingsController(IButtonSettingRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ButtonSettingCollection> List([FromQuery] ButtonSettingQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{ButtonSettingId}")]
        [HalRel(CrudRels.Get)]
        public async Task<ButtonSetting> Get(Guid buttonSettingId)
        {
            return await repo.Get(buttonSettingId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new buttonSetting")]
        public async Task<ButtonSetting> Add([FromBody]ButtonSettingInput buttonSetting)
        {
            return await repo.Add(buttonSetting);
        }

        [HttpPut("{ButtonSettingId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update buttonSetting")]
        public async Task<ButtonSetting> Update(Guid buttonSettingId, [FromBody]ButtonSettingInput buttonSetting)
        {
            return await repo.Update(buttonSettingId, buttonSetting);
        }

        [HttpDelete("{ButtonSettingId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid buttonSettingId)
        {
            await repo.Delete(buttonSettingId);
        }
    }
}