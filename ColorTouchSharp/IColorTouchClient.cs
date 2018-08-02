using System.Threading.Tasks;

namespace ColorTouchSharp
{
    public interface IColorTouchClient
    {
        string Host { get; }
        int MinDelta { get; set; }
        string Name { get; }

        Task<bool> ChangeSettingsAsync(ThermostatSetting setting);
        Task<ApiInfo> GetApiInfoAsync();
        Task<ThermostatStatus> GetStatusAsync();
    }
}