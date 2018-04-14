using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class HueSwitchPosition
    {
        /// <summary>
        /// The value to set the switch to.
        /// </summary>
        [Required]
        public String Value { get; set; }

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
