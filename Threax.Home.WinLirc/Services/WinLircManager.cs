using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Threax.Home.WinLirc.ClientSocket;

namespace Threax.Home.WinLirc.Services
{
    public class WinLircManager : IWinLircManager
    {
        private IWinLircConnection connection;
        private ILogger<WinLircManager> logger;

        public WinLircManager(ILogger<WinLircManager> logger, IWinLircConnection connection)
        {
            this.logger = logger;
            this.connection = connection;
        }

        public async Task PushButton(String device, String button)
        {
            var result = await connection.SendMessage(device, button);
            logger.LogInformation("WinLirc result: " + result);
        }
    }
}
