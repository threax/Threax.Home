using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Hue.Services
{
    /// <summary>
    /// This class wraps the hue client and throttles access to the actual hue bridge.
    /// </summary>
    public class SyncedHueClient : IDisposable
    {
        private SemaphoreSlimLock locker = new SemaphoreSlimLock();
        private LocalHueClient client;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SyncedHueClient()
        {
            
        }

        /// <summary>
        /// Clean up the lock.
        /// </summary>
        public void Dispose()
        {
            locker.Dispose();
        }

        /// <summary>
        /// Get the lights.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Light>> GetLightsAsync()
        {
            return await locker.Run(async () =>
            {
                EnsureClient();
                return await client.GetLightsAsync();
            });
        }

        /// <summary>
        /// Get a single light.
        /// </summary>
        /// <param name="id">The id of the light to get.</param>
        /// <returns></returns>
        public async Task<Light> GetLightAsync(String id)
        {
            return await locker.Run(async () =>
            {
                EnsureClient();
                return await client.GetLightAsync(id);
            });
        }

        /// <summary>
        /// Send a LightCommand.
        /// </summary>
        /// <param name="command">The command to send.</param>
        /// <param name="lightList">The list of lights to send the command to.</param>
        /// <returns>void</returns>
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

        /// <summary>
        /// The host ip address.
        /// </summary>
        public String HostIp { get; set; }

        /// <summary>
        /// The app key to access the api.
        /// </summary>
        public String AppKey { get; set; }
    }
}
