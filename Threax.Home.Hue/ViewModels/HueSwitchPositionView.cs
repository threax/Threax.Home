using System;
using Threax.Home.Core;

namespace Threax.Home.Hue.ViewModels
{
    /// <summary>
    /// View model for switch position.
    /// </summary>
    public class HueSwitchPositionView : ISwitch
    {
        public string Subsystem { get; set; } = "Hue";

        /// <summary>
        /// The id of the switch.
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// The value of the switch.
        /// </summary>
        public String Value { get; set; }

        /// <summary>
        /// The brightness to set.
        /// </summary>
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        public string HexColor { get; set; }

        /// <summary>
        /// The name of the light.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The name of the bridge.
        /// </summary>
        public String Bridge { get; set; }
    }
}
