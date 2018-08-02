using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Q42.HueApi;

namespace Threax.Home.Hue.Services
{
    public interface IHueClient : IDisposable
    {
        Task<Light> GetLightAsync(string id);
        Task<IEnumerable<Light>> GetLightsAsync();
        Task SendCommandAsync(LightCommand command, IEnumerable<string> lightList = null);
    }
}