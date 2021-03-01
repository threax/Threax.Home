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

namespace Threax.Home.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class ThermostatsController : Controller
    {
        private Repository.IThermostatRepository repo;

        public ThermostatsController(Repository.IThermostatRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<ThermostatCollection> List([FromQuery] ThermostatQuery query, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var result = await repo.List(query);

            if(query.UpdateStatus && query.ThermostatId != null)
            {
                //Allow status update for 1 item
                var cached = result.Items.FirstOrDefault();
                if (cached != null)
                {
                    var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
                    var item = await repo.Update(cached.ThermostatId, live);
                    return new ThermostatCollection(query, 1, new Thermostat[] { item });
                }
            }

            return result;
        }

        [HttpPost("[action]")]
        [HalRel(nameof(AddNewThermostats))]
        [Authorize(Roles = Roles.EditThermostats)]
        public async Task AddNewThermostats([FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var items = await thermostats.List();
            await repo.AddMissing(items);
        }

        [HttpGet("{ThermostatId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Thermostat> Get(Guid thermostatId, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var cached = await repo.Get(thermostatId);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(thermostatId, live);
        }

        [HttpPut("{ThermostatId}")]
        [HalRel(CrudRels.Update)]
        [Authorize(Roles = Roles.EditThermostats)]
        [AutoValidate("Cannot update thermostat")]
        public async Task<Thermostat> Update(Guid thermostatId, [FromBody]ThermostatInput thermostat, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var cached = await repo.Get(thermostatId);
            thermostat.Bridge = cached.Bridge;
            thermostat.Subsystem = cached.Subsystem;
            thermostat.Id = cached.Id;
            await thermostats.Set(thermostat);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(thermostatId, live);
        }

        [HttpPut("[action]/{ThermostatId}")]
        [HalRel(nameof(SetTemp))]
        [AutoValidate("Cannot update thermostat")]
        public async Task<Thermostat> SetTemp(Guid thermostatId, [FromBody]ThermostatTempInput tempInput, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var cached = await repo.Get(thermostatId);
            var thermostat = new ThermostatInput();
            thermostat.Bridge = cached.Bridge;
            thermostat.Subsystem = cached.Subsystem;
            thermostat.Id = cached.Id;
            thermostat.HeatTemp = tempInput.HeatTemp;
            thermostat.CoolTemp = tempInput.CoolTemp;
            thermostat.Fan = FanSetting.Auto;
            thermostat.Mode = Mode.Auto;
            await thermostats.Set(thermostat);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(thermostatId, live);
        }

        [HttpPut("[action]/{ThermostatSettingId}")]
        [HalRel(nameof(ApplySetting))]
        [AutoValidate("Cannot apply thermostat setting.")]
        public async Task<Thermostat> ApplySetting(Guid thermostatSettingId, [FromServices]IThermostatSettingRepository settingRepository, [FromServices] IThermostatSubsystemManager<ThermostatInput, Thermostat> thermostats)
        {
            var setting = await settingRepository.Get(thermostatSettingId);
            var cached = await repo.Get(setting.ThermostatId);
            var thermostat = new ThermostatInput();
            thermostat.Bridge = cached.Bridge;
            thermostat.Subsystem = cached.Subsystem;
            thermostat.Id = cached.Id;
            if (setting.On)
            {
                thermostat.HeatTemp = setting.HeatTemp;
                thermostat.CoolTemp = setting.CoolTemp;
                thermostat.Fan = FanSetting.Auto;
                thermostat.Mode = Mode.Auto;
            }
            else
            {
                thermostat.HeatTemp = 70;
                thermostat.CoolTemp = 75;
                thermostat.Fan = FanSetting.Auto;
                thermostat.Mode = Mode.Off;
            }
            await thermostats.Set(thermostat);
            var live = await thermostats.Get(cached.Subsystem, cached.Bridge, cached.Id);
            return await repo.Update(setting.ThermostatId, live);
        }

        [HttpDelete("{ThermostatId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid thermostatId)
        {
            await repo.Delete(thermostatId);
        }
    }
}