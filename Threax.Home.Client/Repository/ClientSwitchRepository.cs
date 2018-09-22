using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Client.Repository
{
    public class ClientSwitchRepository<TIn, TOut> : IClientSwitchRepository<TIn, TOut>
        where TIn : ICoreSwitch, new()
        where TOut : ICoreSwitch, new()
    {
        private IHomeClientManager clientManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientManager"></param>
        public ClientSwitchRepository(IHomeClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        /// <summary>
        /// Get the positions of all the switches.
        /// </summary>
        /// <returns>The switch position status.</returns>
        public async Task<IEnumerable<TOut>> List()
        {
            var switches = new List<TOut>();
            foreach (var bridge in clientManager.GetClientNames())
            {
                var lightInfos = await clientManager.GetClient(bridge).GetSwitches();
                var tasks = lightInfos.Select(async lightInfo => {
                    var light = await clientManager.GetClient(bridge).GetSwitch(lightInfo.Data.SwitchId.ToString());
                    return new TOut()
                    {
                        Brightness = light.Data.Brightness,
                        Value = light.Data.Value,
                        HexColor = light.Data.HexColor,
                        Id = light.Data.SwitchId.ToString(),
                        Name = light.Data.Name,
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
        /// <param name="setting">The position to apply.</param>
        /// <returns>void</returns>
        public async Task Set(TIn setting)
        {
                SetSwitchInput command = new SetSwitchInput()
                {
                    Brightness = setting.Brightness,
                    Value = setting.Value,
                    HexColor = setting.HexColor
            };
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
            var light = await clientManager.GetClient(bridge).GetSwitch(id);

            return new TOut()
            {
                Brightness = light.Data.Brightness,
                Value = light.Data.Value,
                HexColor = light.Data.HexColor,
                Id = light.Data.SwitchId.ToString(),
                Name = light.Data.Name,
                Bridge = bridge,
                Subsystem = SubsystemName
            };
        }

        public String SubsystemName => "HomeClient";
    }
}
