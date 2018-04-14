using MfiSharp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.MFi.Services;

namespace Threax.Home.ZWave.Controllers
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    public class MfiRepository
    {
        private PowerStripManager manager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The PowerStripManager to use.</param>
        public MfiRepository(PowerStripManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="ids">The ids of the switches to lookup.</param>
        /// <param name="strip">The name of the power strip to use.</param>
        /// <returns>The position of the switch.</returns>
        public async Task<IEnumerable<SwitchPosition<int>>> GetPosition(String strip, [FromQuery] IEnumerable<int> ids)
        {
            var settings = await manager.GetClient(strip).GetSettings();
            return settings.Where(i => ids.Contains(i.Index)).Select(i =>
                new SwitchPosition<int>()
                {
                    Id = i.Index,
                    Value = i.On ? "on" : "off"
                });
        }

        /// <summary>
        /// Set the position of a named switch.
        /// </summary>
        /// <param name="positions">The position of the switch.</param>
        /// <param name="strip">The name of the power strip to use.</param>
        public async Task SetPosition(String strip, [FromBody] IEnumerable<SwitchPosition<int>> positions)
        {
            await manager.GetClient(strip).ApplySettings(positions.Select(i =>
            {
                var name = i.Id;
                return new RelaySetting(name, i.Value == "on");
            }));
        }

        /// <summary>
        /// List all the switches.
        /// </summary>
        /// <param name="strip">The name of the power strip to use.</param>
        /// <returns></returns>
        public async Task<IEnumerable<SwitchInfo<int>>> List(String strip)
        {
            var settings = await manager.GetClient(strip).GetSettings();
            return settings.Select(i => new SwitchInfo<int>()
            {
                Id = i.Index,
                Positions = new List<String>() { "on", "off" },
                DisplayName = $"{strip} Relay {i.Index}"
            });
        }
    }
}
