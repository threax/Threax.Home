using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    /// <summary>
    /// Interface for switches.
    /// </summary>
    public interface ISwitch
    {
        /// <summary>
        /// Which type of system the switch belongs to. (Hue, ZWave, etc.)
        /// </summary>
        String Subsystem { get; set; }

        /// <summary>
        /// A logical hardware grouping for the switch.
        /// </summary>
        String Bridge { get; set; }

        /// <summary>
        /// The id of the switch.
        /// </summary>
        String Id { get; set; }

        /// <summary>
        /// The value of the switch.
        /// </summary>
        String Value { get; set; }

        /// <summary>
        /// The brightness to set.
        /// </summary>
        byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        string HexColor { get; set; }

        /// <summary>
        /// The name of the switch. Suitable for display.
        /// </summary>
        String Name { get; set; }
    }
}
