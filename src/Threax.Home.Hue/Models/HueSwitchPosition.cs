using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.Hue.Controllers;

namespace Threax.Home.Hue.Models
{
    /// <summary>
    /// The switch position for a hue bulb
    /// </summary>
    [HalModel]
    public class HueSwitchPosition : SwitchPosition<String>, IHexColor, IBrightness
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
