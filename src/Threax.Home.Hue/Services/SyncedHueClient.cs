using Q42.HueApi;
using Q42.HueApi.Interfaces;
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
        private LocalHueClient client;

        public SyncedHueClient()
        {
            
        }

        public void Dispose()
        {
            locker.Dispose();
        }

        public async Task<IEnumerable<Light>> GetLightsAsync()
        {
            return await locker.Run(async () =>
            {
                EnsureClient();
                return await client.GetLightsAsync();
            });
        }

        public async Task<Light> GetLightAsync(String id)
        {
            return await locker.Run(async () =>
            {
                EnsureClient();
                return await client.GetLightAsync(id);
            });
        }

        public async Task SendCommandAsync(LightCommand command, IEnumerable<string> lightList = null)
        {
            await locker.Run(async () =>
            {
                EnsureClient();
                await client.SendCommandAsync(command, lightList);
            });
        }

        private void EnsureClient()
        {
            if (client == null)
            {
                client = new LocalHueClient(HostIp);
                client.Initialize(AppKey);
            }
        }

        public String HostIp { get; set; }

        public String AppKey { get; set; }
    }
}
