using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Threax.Home.WinLirc.ClientSocket
{
    static class WinLircConnection
    {
        //Uses the lirc interface
        //http://lirc.org/html/lircd.html

        public static async Task<String> SendMessage(String device, String button)
        {
            using (var tcpClient = await ConnectTcpClient("localhost", 8765))
            {
                using (var tcpStream = tcpClient.GetStream())
                {
                    //var message = ASCIIEncoding.ASCII.GetBytes("LIST\n");
                    var message = ASCIIEncoding.ASCII.GetBytes($"SEND_ONCE {device} {button}\n");
                    await tcpStream.WriteAsync(message, 0, message.Length);
                    return await GetResult(tcpClient, tcpStream);
                }
            }
        }

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

        private static async Task<TcpClient> ConnectTcpClient(String host, int port)
        {
            var client = new TcpClient();
            await client.ConnectAsync(host, port);
            return client;
        }
    }
}
