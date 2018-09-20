using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.ZWave
{
    /// <summary>
    /// Configuration for zwave api.
    /// </summary>
    public class ZWaveConfig
    {
        /// <summary>
        /// The com port of your z-wave device.
        /// </summary>
        public String ComPort { get; set; }

        /// <summary>
        /// Set to true (default) to enable the z wave device
        /// </summary>
        public bool Enabled { get; set; } = false;
    }
}
