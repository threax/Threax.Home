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
    public class SwitchController : Controller
    {
        private ZWaveController zwave;

        public SwitchController(ZWaveController zwave)
        {
            this.zwave = zwave;
        }

        /// <summary>
        /// Get the position of a named switch.
        /// </summary>
        /// <param name="name">The name of the switch to lookup.</param>
        /// <returns>The position of the switch.</returns>
        [HttpGet]
        public async Task<SwitchPosition> GetPosition([FromQuery] String name)
        {
            //Hardcoded, for now
            Basic com;
            switch (name.ToLowerInvariant())
            {
                case "bedroomfan":
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
            return new SwitchPosition()
            {
                Name = name,
                Value = value
            };
        }

        /// <summary>
        /// Set the position of a named switch.
        /// </summary>
        /// <param name="position">The position of the switch.</param>
        [HttpPut]
        public async Task SetPosition([FromBody] SwitchPosition position)
        {
            //Hardcoded, for now
            Basic com;
            switch (position.Name.ToLowerInvariant())
            {
                case "bedroomfan":
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
                    throw new ErrorResultException($"{position.Value} is not a valid position for {position.Name}");
            }
        }

        [HttpGet]
        public IEnumerable<SwitchInfo> List()
        {
            //Hardcoded
            yield return new SwitchInfo()
            {
                Name = "BedroomFan",
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
