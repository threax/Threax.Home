using System;
using System.Collections.Generic;

namespace Threax.Home.MFi.Services
{
    public interface IPowerStripManager
    {
        void Dispose();
        IPowerStrip GetClient(string name);
        IEnumerable<String> ClientNames { get; }
    }
}