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

        /// <summary>
        /// The hdmi port the cec usb device is connected to. Does not have to physically match the plugged in location. Default: -1, do not set value.
        /// </summary>
        public int HdmiPort { get; set; } = -1;
    }
}
