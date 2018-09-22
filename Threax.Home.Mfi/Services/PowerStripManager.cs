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
    public class PowerStripManager : IPowerStripManager
    {
        private Dictionary<String, IPowerStrip> clients = new Dictionary<string, IPowerStrip>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public PowerStripManager()
        {
            
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
        public IPowerStrip GetClient(String name)
        {
            return this.clients[name];
        }

        public void SetClient(String name, IPowerStrip client)
        {
            this.clients[name] = client;
        }

        public IEnumerable<String> ClientNames => clients.Keys;
    }
}
