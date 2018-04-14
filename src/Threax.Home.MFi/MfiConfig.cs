using MfiSharp;
using System;
using System.Collections.Generic;

namespace Threax.Home.MFi
{
    public class PowerStripConfig
    {
        /// <summary>
        /// The host ip of the power strip.
        /// </summary>
        public String Host { get; set; }

        /// <summary>
        /// The user name to log in with.
        /// </summary>
        public String User { get; set; }

        /// <summary>
        /// The password to log in with.
        /// </summary>
        public String Pass { get; set; }

        /// <summary>
        /// The number of relays on the power strip.
        /// </summary>
        public int RelayCount { get; set; }
    }

    public class MfiConfig
    {
        public Dictionary<string, PowerStripConfig> Clients { get; set; }
    }
}