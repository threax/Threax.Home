using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.WinLirc.ClientSocket
{
    public class WinLircConnection : IWinLircConnection, IDisposable
    {
        private SemaphoreSlimLock readLock = new SemaphoreSlimLock();
        private TcpClient tcpClient;
        private NetworkStream tcpStream;

        public WinLircConnection(WinLircConfig config)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(config.Host, config.Port);
            tcpStream = tcpClient.GetStream();
        }

        public void Dispose()
        {
            tcpStream.Dispose();
            tcpClient.Dispose();
            readLock.Dispose();
        }

        //Uses the lirc interface
        //http://lirc.org/html/lircd.html

        public async Task<String> SendMessage(String device, String button)
        {
            return await readLock.Run(async () =>
            {
                var message = ASCIIEncoding.ASCII.GetBytes($"SEND_ONCE {device} {button}\n");
                await tcpStream.WriteAsync(message, 0, message.Length);
                return await GetResult(tcpClient, tcpStream);
            });
        }

        //Basically from the ms docs
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient.getstream?view=netframework-4.7.2
        private static async Task<string> GetResult(TcpClient tcpClient, NetworkStream tcpStream)
        {
            var bytes = new byte[tcpClient.ReceiveBufferSize];

            // Read can return anything from 0 to numBytesToRead. 
            // This method blocks until at least one byte is read.
            await tcpStream.ReadAsync(bytes, 0, (int)tcpClient.ReceiveBufferSize);

            // Returns the data received from the host to the console.
            string returndata = Encoding.ASCII.GetString(bytes);

            var lastEndline = returndata.LastIndexOf("\n");
            if (lastEndline == -1)
            {
                throw new InvalidOperationException("Return string from WinLirc did not have a trailing newline.");
            }

            return returndata.Substring(0, lastEndline);
        }
    }
}
