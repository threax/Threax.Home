using Microsoft.AspNetCore.Mvc;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.OriginalWithModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.Hue.Models;
using Threax.Home.Hue.Services;

namespace Threax.Home.Hue.Controllers
{
    /// <summary>
    /// Color switch controller for hue lights.
    /// </summary>
    [Route("{bridge}/[controller]/[action]")]
    public class SwitchController : Controller
    {
        private HueClientManager clientManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientManager"></param>
        public SwitchController(HueClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        /// <summary>
        /// Set the switch position for the given color switch on the given bridge.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="name">The name of the light to set.</param>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut]
        public async Task SetPosition(String bridge, [FromQuery] String name, [FromBody] HueSwitchPosition settings)
        {
            LightCommand command = new LightCommand()
            {
                Brightness = settings.Brightness,
                On = settings.Value == "on"
            };
            if (settings.HexColor != null)
            {
                command.SetColor(new RGBColor(settings.HexColor));
            }
            await clientManager.GetClient(bridge).SendCommandAsync(command);
        }

        /// <summary>
        /// Get the position of the switch.
        /// </summary>
        /// <param name="bridge">The bridge.</param>
        /// <param name="name">The name of the switch.</param>
        /// <returns>The switch position status.</returns>
        [HttpGet]
        public async Task<HueSwitchPosition> GetPosition(String bridge, [FromQuery] String name)
        {
            var light = await clientManager.GetClient(bridge).GetLightAsync(name);
            var position = new HueSwitchPosition()
            {
                Brightness = light.State.Brightness,
                Value = light.State.On ? "on" : "off",
                HexColor = light.State.ToHex(),
                Name = light.Id
            };

            return position;
        }

        /// <summary>
        /// Get a list of all the color switches supported by this api on the given bridge.
        /// </summary>
        /// <param name="bridge">The bridge to lookup.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SwitchInfo>> List(String bridge)
        {
            var lights = await clientManager.GetClient(bridge).GetLightsAsync();
            return lights.Select(i => new SwitchInfo()
            {
                Name = i.Id,
                DisplayName = i.Name,
                Positions = new List<string>() { "on", "off" },
                SwitchFeatures = HueSwitchPosition.Features
            });
        }
    }


}
