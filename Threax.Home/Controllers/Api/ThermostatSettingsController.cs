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
    public partial class ThermostatSettingsController : Controller
    {
        private IThermostatSettingRepository repo;

        public ThermostatSettingsController(IThermostatSettingRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ThermostatSettingCollection> List([FromQuery] ThermostatSettingQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{ThermostatSettingId}")]
        [HalRel(CrudRels.Get)]
        public async Task<ThermostatSetting> Get(Guid thermostatSettingId)
        {
            return await repo.Get(thermostatSettingId);
        }

        [HttpGet("[action]/{ThermostatId}")]
        [HalRel(nameof(GetForThermostat))]
        public async Task<ThermostatSettingCollection> GetForThermostat(Guid thermostatId)
        {
            return await repo.List(new ThermostatSettingQuery()
            {
                ThermostatId = thermostatId,
                Limit = int.MaxValue,
                Offset = 0,
            });
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new thermostatSetting")]
        [Authorize(Roles = Roles.EditThermostatSettings)]
        public async Task<ThermostatSetting> Add([FromBody]ThermostatSettingInput thermostatSetting)
        {
            return await repo.Add(thermostatSetting);
        }

        [HttpPut("{ThermostatSettingId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update thermostatSetting")]
        [Authorize(Roles = Roles.EditThermostatSettings)]
        public async Task<ThermostatSetting> Update(Guid thermostatSettingId, [FromBody]ThermostatSettingInput thermostatSetting)
        {
            return await repo.Update(thermostatSettingId, thermostatSetting);
        }

        [HttpDelete("{ThermostatSettingId}")]
        [HalRel(CrudRels.Delete)]
        [Authorize(Roles = Roles.EditThermostatSettings)]
        public async Task Delete(Guid thermostatSettingId)
        {
            await repo.Delete(thermostatSettingId);
        }
    }
}