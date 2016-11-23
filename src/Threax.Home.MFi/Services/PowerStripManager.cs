using MfiSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.MFi.Services
{
    /// <summary>
    /// This class manages multiple power strip clients.
    /// </summary>
    public class PowerStripManager
    {
        private Dictionary<String, SynchedPowerStrip> clients;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="clients">The clients to manage.</param>
        public PowerStripManager(Dictionary<String, SynchedPowerStrip> clients)
        {
            this.clients = clients;
        }

        /// <summary>
        /// Clean up the clients.
        /// </summary>
        public void Dispose()
        {
            foreach (var client in clients.Values)
            {
                client.Dispose();
            }
        }

        /// <summary>
        /// Get a specific client.
        /// </summary>
        /// <param name="name">The name of the client to get.</param>
        /// <returns>The client.</returns>
        public SynchedPowerStrip GetClient(String name)
        {
            return this.clients[name];
        }
    }
}
