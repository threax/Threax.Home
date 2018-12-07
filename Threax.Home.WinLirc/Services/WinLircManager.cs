using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;
using Threax.Home.WinLirc.ClientSocket;

namespace Threax.Home.WinLirc.Services
{
    public class WinLircManager : IWinLircManager
    {
        private SemaphoreSlimLock readLock = new SemaphoreSlimLock();

        public WinLircManager()
        {

        }

        public void Dispose()
        {
            readLock.Dispose();
        }

        public async Task PushButton(String device, String button)
        {
            await readLock.Run(() =>
            {
                //WinLirc.SendMessage($"{device} {button}");
                WinLircConnection.SendMessage(device, button);
            });
        }
    }
}
