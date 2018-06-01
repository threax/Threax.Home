using System;
using System.Collections.Generic;
using System.Text;

namespace ColorTouchSharp
{
    public class ColorTouchClientManager : IColorTouchClientManager
    {
        private Dictionary<String, IColorTouchClient> clients = new Dictionary<string, IColorTouchClient>();

        public ColorTouchClientManager()
        {

        }

        public void AddClient(IColorTouchClient client)
        {
            this.clients.Add(client.Name, client);
        }

        public IColorTouchClient GetClient(String name)
        {
            return this.clients[name];
        }

        public IEnumerable<IColorTouchClient> Clients => this.clients.Values;
    }
}
