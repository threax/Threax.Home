using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.LibCec
{
    public class LibCecConfig
    {
        /// <summary>
        /// Set this to true to enable this plugin. Default: false.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The com port of the CEC Adapter. Default: "com3"
        /// </summary>
        public String Port { get; set; } = "com3";
    }
}
