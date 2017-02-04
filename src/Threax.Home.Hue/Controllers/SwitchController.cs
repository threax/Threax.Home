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
    [Route("[controller]/{Bridge}")]
    [ResponseCache(NoStore=true)]
    public class SwitchController : Controller
    {
        public static class Rels
        {
            public const String ListSwitches = "ListSwitches";
            public const String SetSwitches = "SetSwitches";
            public const String SetSwitch = "SetSwitch";
            public const String GetSwitch = "GetSwitch";
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
        /// Set multiple switch positions.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut]
        [HalRel(Rels.SetSwitches)]
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
        /// Get the positions of all the switches.
        /// </summary>
        /// <param name="bridge">The bridge.</param>
        /// <returns>The switch position status.</returns>
        [HttpGet]
        [HalRel(Rels.ListSwitches)]
        public async Task<HueSwitchCollection> List(String bridge)
        {
            var lightInfos = await clientManager.GetClient(bridge).GetLightsAsync();

            var switches = await Task.WhenAll<HueSwitchPositionView>(
                lightInfos.Select(lightInfo => clientManager.GetClient(bridge).GetLightAsync(lightInfo.Id)
                .ContinueWith(ante =>
                {
                    var light = ante.Result;
                    var position = new HueSwitchPositionView()
                    {
                        Brightness = light.State.Brightness,
                        Value = light.State.On ? "on" : "off",
                        HexColor = light.State.ToHex(),
                        Id = light.Id,
                        Name = light.Name,
                        Bridge = bridge
                    };
                    return position;
                }))
            );

            return new HueSwitchCollection(switches.ToList(), bridge);
        }

        /// <summary>
        /// Set the switch position of an individual switch.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="id">The id of the light to set.</param>
        /// <param name="setting">The position to apply.</param>
        /// <returns>void</returns>
        [HttpPut("{Id}")]
        [HalRel(Rels.SetSwitch)]
        public async Task Set(String bridge, String id, [FromBody] HueSwitchPosition setting)
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
            await clientManager.GetClient(bridge).SendCommandAsync(command, new String[] { id });
        }

        /// <summary>
        /// Get the status of a single switch.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="id">The id of the light to get.</param>
        /// <returns>void</returns>
        [HttpGet("{Id}")]
        [HalRel(Rels.GetSwitch)]
        public async Task<HueSwitchPositionView> Get(String bridge, String id)
        {
            var light = await clientManager.GetClient(bridge).GetLightAsync(id);

            return new HueSwitchPositionView()
            {
                Brightness = light.State.Brightness,
                Value = light.State.On ? "on" : "off",
                HexColor = light.State.ToHex(),
                Id = light.Id,
                Name = light.Name,
                Bridge = bridge
            };
        }
    }
}
