using System;
using System.Threading.Tasks;

namespace Threax.Home.WinLirc.Services
{
    public interface IWinLircManager
    {
        Task PushButton(String device, String button);
    }
}