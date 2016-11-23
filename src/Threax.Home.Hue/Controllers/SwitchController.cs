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
    public class SwitchController : Controller, ISwitchController<HueSwitchPosition, String, String>
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
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut]
        public async Task SetPosition(String bridge, [FromBody] IEnumerable<HueSwitchPosition> settings)
        {
            foreach(var setting in settings)
            {
                LightCommand command = new LightCommand()
                {
                    Brightness = setting.Brightness,
                    On = setting.Value == "on"
                };
                if (setting.HexColor != null)
                {
                    command.SetColor(new RGBColor(setting.HexColor));
                }
                await clientManager.GetClient(bridge).SendCommandAsync(command, new String[] { setting.Id });
            }
        }

        /// <summary>
        /// Get the position of the switch.
        /// </summary>
        /// <param name="bridge">The bridge.</param>
        /// <param name="ids">The ids of the switches to get.</param>
        /// <returns>The switch position status.</returns>
        [HttpGet]
        public async Task<IEnumerable<HueSwitchPosition>> GetPosition(String bridge, [FromQuery] IEnumerable<String> ids)
        {
            return await Task.WhenAll<HueSwitchPosition>(
                ids.Select(id => clientManager.GetClient(bridge).GetLightAsync(id)
                .ContinueWith(ante =>
                {
                    var light = ante.Result;
                    var position = new HueSwitchPosition()
                    {
                        Brightness = light.State.Brightness,
                        Value = light.State.On ? "on" : "off",
                        HexColor = light.State.ToHex(),
                        Id = light.Id
                    };
                    return position;
                }))
            );
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
                Id = i.Id,
                DisplayName = i.Name,
                Positions = new List<string>() { "on", "off" },
                SwitchFeatures = HueSwitchPosition.Features
            });
        }
    }


}
