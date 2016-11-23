using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.ExceptionToJson;
using Threax.Home.Core;
using ZWave;
using ZWave.CommandClasses;

namespace Threax.Home.ZWave.Controllers
{
    /// <summary>
    /// Manage switches.
    /// </summary>
    [Route("[controller]/[action]")]
    public class SwitchController : Controller, ISwitchController<SwitchPosition<int>, int>
    {
        private ZWaveController zwave;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zwave">The ZWaveController to use.</param>
        public SwitchController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="ids">The ids of the switches to lookup.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchPosition<int>>> GetPosition([FromQuery] IEnumerable<int> ids)
        {
            var positions = new List<SwitchPosition<int>>();
            foreach(var id in ids)
            {
                //Hardcoded, for now
                Basic com;
                switch (id)
                {
                    case 2:
                        com = await GetBasicCommand(2);
                        break;
                    default:
                        throw new FileNotFoundException();
                }

                var b = (await com.Get()).Value;
                String value = null;
                if (b == 0)
                {
                    value = "off";
                }
                else if (b < 10)
                {
                    value = "low";
                }
                else if (b < 60)
                {
                    value = "med";
                }
                else if (b < 100)
                {
                    value = "high";
                }
                positions.Add(new SwitchPosition<int>()
                {
                    Id = id,
                    Value = value
                });
            }
            return positions;
        }

        /// <summary>
        /// Set the position of a named switch.
        /// </summary>
        /// <param name="positions">The position of the switch.</param>
        [HttpPut]
        public async Task SetPosition([FromBody] IEnumerable<SwitchPosition<int>> positions)
        {
            foreach (var position in positions)
            {
                //Hardcoded, for now
                Basic com;
                switch (position.Id)
                {
                    case 2:
                        com = await GetBasicCommand(2);
                        break;
                    default:
                        throw new FileNotFoundException();
                }

                switch (position.Value.ToLowerInvariant())
                {
                    case "off":
                        await com.Set(0);
                        break;
                    case "low":
                        await com.Set(1);
                        break;
                    case "med":
                        await com.Set(50);
                        break;
                    case "high":
                        await com.Set(99);
                        break;
                    default:
                        throw new ErrorResultException($"{position.Value} is not a valid position for {position.Id}");
                }
            }
        }

        /// <summary>
        /// List all the switches.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchInfo<int>>> List()
        {
            return await Task.FromResult(GetSwitches());
        }

        private IEnumerable<SwitchInfo<int>> GetSwitches()
        {
            //Hardcoded
            yield return new SwitchInfo<int>()
            {
                Id = 2,
                DisplayName = "Bedroom Fan",
                Positions = new List<String>() { "off", "low", "med", "high" }
            };
        }

        private async Task<Basic> GetBasicCommand(byte nodeId)
        {
            return (await zwave.GetNodes()).First(n => n.NodeID == nodeId).GetCommandClass<Basic>();
        }
    }
}
