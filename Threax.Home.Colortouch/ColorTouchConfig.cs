using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Colortouch
{
    public class ColorTouchClientConfig
    {
        /// <summary>
        /// The host url to connect to.
        /// </summary>
        public String Host { get; set; }
    }

    public class ColorTouchConfig
    {
        /// <summary>
        /// The clients to connect to.
        /// </summary>
        public Dictionary<String, ColorTouchClientConfig> Clients { get; set; }

        /// <summary>
        /// Set this to true (default) to enable the color touch library.
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
}
