using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Client
{
    /// <summary>
    /// This class manages multiple named hue clients.
    /// </summary>
    public class HomeClientManager : IHomeClientManager
    {
        private Dictionary<String, HomeClient> clients = new Dictionary<String, HomeClient>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="clients">The clients to manage.</param>
        public HomeClientManager()
        {
            
        }

        /// <summary>
        /// Get a specific client.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <returns>The client</returns>
        public HomeClient GetClient(String name)
        {
            return this.clients[name];
        }

        /// <summary>
        /// Get a specific client.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <returns>The client</returns>
        public void SetClient(String name, HomeClient client)
        {
            this.clients[name] = client;
        }

        public IEnumerable<String> GetClientNames()
        {
            return this.clients.Keys;
        }
    }
}
