using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.OriginalWithModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.Hue.Services;

namespace Threax.Home.Hue.Repository
{
    public class HueSwitchRepository<TIn, TOut> : IHueSwitchRepository<TIn, TOut>
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        private IHueClientManager clientManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientManager"></param>
        public HueSwitchRepository(IHueClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        ///// <summary>
        ///// Set multiple switch positions.
        ///// </summary>
        ///// <param name="bridge">The bridge to use.</param>
        ///// <param name="settings">The position to apply.</param>
        ///// <returns>void</returns>
        //[HttpPut]
        //[HalRel(Rels.SetSwitches)]
        //public async Task Set(String bridge, [FromBody] IEnumerable<HueSwitchPosition> settings)
        //{
        //    foreach (var setting in settings)
        //    {
        //        LightCommand command = new LightCommand()
        //        {
        //            Brightness = setting.Brightness,
        //            On = setting.Value == "on"
        //        };
        //        if (setting.HexColor != null)
        //        {
        //            command.SetColor(new RGBColor(setting.HexColor));
        //        }
        //        await clientManager.GetClient(bridge).SendCommandAsync(command, new String[] { setting.Id });
        //    }
        //}

        /// <summary>
        /// Get the positions of all the switches.
        /// </summary>
        /// <param name="bridge">The bridge.</param>
        /// <returns>The switch position status.</returns>
        public async Task<IEnumerable<TOut>> List()
        {
            var switches = new List<TOut>();
            foreach (var bridge in clientManager.GetClientNames())
            {
                var lightInfos = await clientManager.GetClient(bridge).GetLightsAsync();
                var tasks = lightInfos.Select(async lightInfo => {
                    var light = await clientManager.GetClient(bridge).GetLightAsync(lightInfo.Id);
                    return new TOut()
                    {
                        Brightness = light.State.Brightness,
                        Value = light.State.On ? "on" : "off",
                        HexColor = light.State.ToHex(),
                        Id = light.Id,
                        Name = light.Name,
                        Bridge = bridge,
                        Subsystem = SubsystemName
                    };
                });
                foreach(var task in tasks)
                {
                    switches.Add(await task);
                }
            }

            return switches.ToList();
        }

        /// <summary>
        /// Set the switch position of an individual switch.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="id">The id of the light to set.</param>
        /// <param name="setting">The position to apply.</param>
        /// <returns>void</returns>
        public async Task Set(TIn setting)
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
            await clientManager.GetClient(setting.Bridge).SendCommandAsync(command, new String[] { setting.Id });
        }

        /// <summary>
        /// Get the status of a single switch.
        /// </summary>
        /// <param name="bridge">The bridge to use.</param>
        /// <param name="id">The id of the light to get.</param>
        /// <returns>void</returns>
        public async Task<TOut> Get(String bridge, String id)
        {
            var light = await clientManager.GetClient(bridge).GetLightAsync(id);

            return new TOut()
            {
                Brightness = light.State.Brightness,
                Value = light.State.On ? "on" : "off",
                HexColor = light.State.ToHex(),
                Id = light.Id,
                Name = light.Name,
                Bridge = bridge,
                Subsystem = SubsystemName
            };
        }

        public String SubsystemName => "Hue";
    }
}
