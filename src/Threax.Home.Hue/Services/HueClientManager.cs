using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Hue.Services
{
    /// <summary>
    /// This class manages multiple named hue clients.
    /// </summary>
    public class HueClientManager : IDisposable
    {
        private Dictionary<String, SyncedHueClient> clients;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="clients">The clients to manage.</param>
        public HueClientManager(Dictionary<String, SyncedHueClient> clients)
        {
            this.clients = clients;
        }

        /// <summary>
        /// Clean up clients.
        /// </summary>
        public void Dispose()
        {
            foreach(var client in clients.Values)
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Get a specific client.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <returns>The client</returns>
        public SyncedHueClient GetClient(String name)
        {
            return this.clients[name];
        }

        public IEnumerable<String> GetClientNames()
        {
            return this.clients.Keys;
        }
    }
}
