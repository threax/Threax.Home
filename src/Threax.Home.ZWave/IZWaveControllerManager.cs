using ZWave;

namespace Threax.Home.ZWave
{
    public interface IZWaveControllerManager
    {
        ZWaveController Controller { get; }
    }
}