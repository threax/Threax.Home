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
    }
}