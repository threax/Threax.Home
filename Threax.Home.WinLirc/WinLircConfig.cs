using System;
using System.Collections.Generic;

namespace Threax.Home.WinLirc
{
    public class WinLircConfig
    {
        /// <summary>
        /// Devices with list of approved button commands to send.
        /// </summary>
        public Dictionary<String, List<String>> Devices { get; set; }

        /// <summary>
        /// Set this to true to enable winlirc. Default: false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The host. Default: localhost
        /// </summary>
        public String Host { get; set; } = "localhost";

        /// <summary>
        /// The port. Default: 8765
        /// </summary>
        public int Port { get; set; } = 8765;
    }
}