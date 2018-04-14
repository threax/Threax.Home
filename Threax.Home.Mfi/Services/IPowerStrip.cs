using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MfiSharp;

namespace Threax.Home.MFi.Services
{
    public interface IPowerStrip : IDisposable
    {
        Task ApplySettings(IEnumerable<RelaySetting> settings);
        Task<IEnumerable<RelaySetting>> GetSettings();
    }
}