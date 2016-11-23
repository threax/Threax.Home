using MfiSharp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.ExceptionToJson;
using Threax.Home.Core;
using Threax.Home.MFi.Services;

namespace Threax.Home.ZWave.Controllers
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    [Route("{strip}/[controller]/[action]")]
    public class SwitchController : Controller
    {
        private PowerStripManager manager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The PowerStripManager to use.</param>
        public SwitchController(PowerStripManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="name">The name of the switch to lookup.</param>
        /// <param name="strip">The name of the power strip to use.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet]
        public async Task<SwitchPosition> GetPosition(String strip, [FromQuery] int name)
        {
            var settings = await manager.GetClient(strip).GetSettings();
            var setting = settings.First(i => i.Index == name);
            return new SwitchPosition()
            {
                Name = name.ToString(),
                Value = setting.On ? "on" : "off"
            };
        }

        /// <summary>
        /// Set the position of a named switch.
        /// </summary>
        /// <param name="position">The position of the switch.</param>
        /// <param name="strip">The name of the power strip to use.</param>
        [HttpPut]
        public async Task SetPosition(String strip, [FromBody] SwitchPosition position)
        {
            int index = int.Parse(position.Name);
            bool on = position.Value == "on";

            RelaySetting relaySetting = new RelaySetting(index, on);
            await manager.GetClient(strip).ApplySettings(new RelaySetting[] { relaySetting });
        }

        /// <summary>
        /// List all the switches.
        /// </summary>
        /// <param name="strip">The name of the power strip to use.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchInfo>> List(String strip)
        {
            var settings = await manager.GetClient(strip).GetSettings();
            return settings.Select(i => new SwitchInfo()
            {
                Name = i.Index.ToString(),
                Positions = new List<String>() { "on", "off" },
                DisplayName = $"{strip} Relay {i.Index}"
            });
        }
    }
}
