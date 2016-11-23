using Microsoft.AspNetCore.Mvc;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.OriginalWithModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.Hue.Services;

namespace Threax.Home.Hue.Controllers
{
    [Route("{bridge}/[controller]/[action]")]
    public class ColorSwitchController : Controller
    {
        private HueClientManager clientManager;

        public ColorSwitchController(HueClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [HttpPut]
        public async Task SetPosition(String bridge, [FromQuery] String name, [FromBody] ColorSwitchPosition settings)
        {
            LightCommand command = new LightCommand()
            {
                Brightness = settings.Brightness,
                On = settings.On
            };
            if (settings.Color != null)
            {
                command.SetColor(new RGBColor(settings.Color));
            }
            await clientManager.GetClient(bridge).SendCommandAsync(command);
        }

        [HttpGet]
        public async Task<ColorSwitchPosition> GetPosition(String bridge, [FromQuery] String name)
        {
            var light = await clientManager.GetClient(bridge).GetLightAsync(name);
            var position = new ColorSwitchPosition()
            {
                Brightness = light.State.Brightness,
                On = light.State.On,
                Color = light.State.ToHex()
            };

            return position;
        }

        [HttpGet]
        public async Task<IEnumerable<ColorSwitchInfo>> List(String bridge)
        {
            var lights = await clientManager.GetClient(bridge).GetLightsAsync();
            return lights.Select(i => new ColorSwitchInfo()
            {
                Name = i.Id,
                DisplayName = i.Name
            });
        }
    }


}
