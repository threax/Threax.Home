using System;
using System.Threading.Tasks;

namespace Threax.Home.WinLirc.ClientSocket
{
    public interface IWinLircConnection : IDisposable
    {
        Task<string> SendMessage(string device, string button);
    }
}