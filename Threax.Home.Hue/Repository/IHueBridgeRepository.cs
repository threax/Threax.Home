using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Repository
{
    public interface IHueBridgeRepository
    {
        BridgeCollection List();
    }
}