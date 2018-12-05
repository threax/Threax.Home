using System;
using System.Threading.Tasks;

namespace Threax.Home.WinLirc.Services
{
    public interface IWinLircManager : IDisposable
    {
        Task PushButton(String device, String button);
    }
}