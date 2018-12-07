using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private ILogger<WinLircManager> logger;

        public WinLircManager(ILogger<WinLircManager> logger)
        {
            this.logger = logger;
        }

        public void Dispose()
        {
            readLock.Dispose();
        }

        public async Task PushButton(String device, String button)
        {
            await readLock.Run(async () =>
            {
                var result = await WinLircConnection.SendMessage(device, button);
                logger.LogInformation("WinLirc result: " + result);
            });
        }
    }
}
