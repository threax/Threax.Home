using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Hue.Services
{
    public class HueClientManager : IDisposable
    {
        private Dictionary<String, SyncedHueClient> clients;

        public HueClientManager(Dictionary<String, SyncedHueClient> clients)
        {
            this.clients = clients;
        }

        public void Dispose()
        {
            foreach(var client in clients.Values)
            {
                client.Dispose();
            }
        }

        public SyncedHueClient GetClient(String name)
        {
            return this.clients[name];
        }
    }
}
