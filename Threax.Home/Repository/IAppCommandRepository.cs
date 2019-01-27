using System;
using System.Threading.Tasks;
using Threax.Home.InputModels;
using Threax.Home.ViewModels;

namespace Threax.Home.Repository
{
    public interface IAppCommandRepository
    {
        Task<AppCommand> Get(Guid buttonId);
        Task<AppCommandCollection> List(AppCommandQuery query);
    }
}