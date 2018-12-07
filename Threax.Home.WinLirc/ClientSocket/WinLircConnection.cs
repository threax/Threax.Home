using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Threax.Home.WinLirc.ClientSocket
{
    static class WinLircConnection
    {
        public static void SendMessage(String device, String button)
        {
            using (Socket s = ConnectSocket("localhost", 8765))
            {
                var result = s.Send(ASCIIEncoding.ASCII.GetBytes($"{device} {button} 1\n"));
            }
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socket?view=netframework-4.7.2
        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            // In this case we know we are only looking for 127.0.0.1
            foreach (IPAddress address in hostEntry.AddressList.Where(i => i.ToString() == "127.0.0.1"))
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }
    }
}
