using System;
using System.Collections.Generic;

namespace Threax.Home.Hue.Services
{
    public interface IHueClientManager : IDisposable
    {
        SyncedHueClient GetClient(string name);
        IEnumerable<string> GetClientNames();
        void SetClient(string name, SyncedHueClient client);
    }
}