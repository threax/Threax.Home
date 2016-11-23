using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// Implementors will have a color property that takes a string with a RRGGBB color string in hex.
    /// </summary>
    public interface IHexColor
    {
        /// <summary>
        /// The color in hex RRGGBB. Null to not modify.
        /// </summary>
        String HexColor { get; set; }
    }
}
