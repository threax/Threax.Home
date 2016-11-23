using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// The position of a color switch.
    /// </summary>
    public class ColorSwitchPosition
    {
        /// <summary>
        /// The brightness of the switch from 0 to 255. Null to not modify.
        /// </summary>
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color of the switch in hex RRGGBB. Null to not modify.
        /// </summary>
        public String Color { get; set; }

        /// <summary>
        /// True for on false for off, null to not modify.
        /// </summary>
        public bool? On { get; set; }
    }
}
