using System;
using System.Collections.Generic;

namespace Threax.Home.Client
{
    public interface IHomeClientManager
    {
        HomeClient GetClient(string name);
        IEnumerable<string> GetClientNames();
        void SetClient(string name, HomeClient client);
    }
}