using System.Threading.Tasks;
using Threax.Home.Hue.Models;
using Threax.Home.Hue.ViewModels;

namespace Threax.Home.Hue.Repository
{
    public interface IHueSwitchRepository
    {
        Task<HueSwitchPositionView> Get(string bridge, string id);
        Task<HueSwitchCollection> List(string bridge);
        Task Set(string bridge, string id, HueSwitchPosition setting);
    }
}