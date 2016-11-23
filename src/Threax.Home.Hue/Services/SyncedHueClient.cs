using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Hue.Services
{
    public class SyncedHueClient : IDisposable
    {
        private SemaphoreSlimLock locker = new SemaphoreSlimLock();
        private HueClient client;

        public SyncedHueClient(HueClient client)
        {
            this.client = client;
        }

        public void Dispose()
        {
            locker.Dispose();
        }

        public async Task SendCommandAsync(LightCommand command, IEnumerable<string> lightList = null)
        {
            await locker.Run(async () =>
            {
                await client.SendCommandAsync(command, lightList);
            });
        }
    }
}
