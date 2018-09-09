using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Client
{
    /// <summary>
    /// This class wraps the hue client and throttles access to the actual hue bridge.
    /// </summary>
    public class HomeClient : IHomeClient
    {
        private EntryPointInjector entryPointInjector;

        public HomeClient(EntryPointInjector entryPointInjector)
        {
            this.entryPointInjector = entryPointInjector;
        }

        public async Task<SwitchResult> GetSwitch(string id)
        {
            var entry = await entryPointInjector.Load();
            var sw = await entry.ListSwitches(new SwitchQuery()
            {
                Limit = 10,
                SwitchId = Guid.Parse(id)
            });
            return sw.Items.First();
        }

        public async Task<IEnumerable<SwitchResult>> GetSwitches()
        {
            var entry = await entryPointInjector.Load();
            var sw = await entry.ListSwitches(new SwitchQuery()
            {
                Limit = int.MaxValue,
            });
            return sw.Items;
        }

        public async Task SendCommandAsync(SwitchInput command, IEnumerable<string> lightList = null)
        {
            var entry = await entryPointInjector.Load();
            var switches = await entry.ListSwitches(new SwitchQuery()
            {
                SwitchIds = lightList.Select(i => Guid.Parse(i)).ToList(),
                Limit = int.MaxValue
            });
            foreach(var sw in switches.Items)
            {
                await sw.Update(command);
            }
        }
    }
}
