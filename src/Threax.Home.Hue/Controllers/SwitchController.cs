using Microsoft.AspNetCore.Mvc;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.OriginalWithModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.Hue.Models;
using Threax.Home.Hue.Services;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Controllers
{
    /// <summary>
    /// Color switch controller for hue lights.
    /// </summary>
    [Route("{bridge}/[controller]")]
    public class SwitchController : Controller//, ISwitchController<HueSwitchPosition, String, String>
    {
        public static class Rels
        {
            public const String List = "listSwitches";
            public const String Set = "setSwitch";
        }

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
        [HalRel(Rels.Set)]
        public async Task Set(String bridge, [FromBody] IEnumerable<HueSwitchPosition> settings)
        {
            foreach (var setting in settings)
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
        /// <returns>The switch position status.</returns>
        [HttpGet]
        [HalRel(Rels.List)]
        public async Task<HueSwitchPositions> List(String bridge)
        {
            var lightInfos = await clientManager.GetClient(bridge).GetLightsAsync();

            var switches = await Task.WhenAll<HueSwitchPosition>(
                lightInfos.Select(lightInfo => clientManager.GetClient(bridge).GetLightAsync(lightInfo.Id)
                .ContinueWith(ante =>
                {
                    var light = ante.Result;
                    var position = new HueSwitchPosition()
                    {
                        Brightness = light.State.Brightness,
                        Value = light.State.On ? "on" : "off",
                        HexColor = light.State.ToHex(),
                        Id = light.Id,
                        Name = light.Name,
                    };
                    return position;
                }))
            );

            return new HueSwitchPositions(switches.ToList(), bridge);
        }
    }
}
