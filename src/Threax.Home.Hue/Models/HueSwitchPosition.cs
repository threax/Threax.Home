using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.Hue.Models
{
    /// <summary>
    /// The switch position for a hue bulb
    /// </summary>
    public class HueSwitchPosition : SwitchPosition, IHexColor, IBrightness
    {
        /// <summary>
        /// The features this switch supports.
        /// </summary>
        public const SwitchFeatures Features = SwitchFeatures.Brightness | SwitchFeatures.Color;

        /// <summary>
        /// The brightness to set.
        /// </summary>
        public byte? Brightness { get; set; }

        /// <summary>
        /// The color to set.
        /// </summary>
        public string HexColor { get; set; }
    }
}
