using ZWave;

namespace Threax.Home.ZWave
{
    public interface IZWaveControllerAccessor
    {
        ZWaveController Controller { get; }
    }
}