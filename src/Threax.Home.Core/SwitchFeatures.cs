using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// The various extra features a switch can have.
    /// </summary>
    [Flags]
    public enum SwitchFeatures
    {
        /// <summary>
        /// Switch does colors.
        /// </summary>
        Color = 1 << 0,

        /// <summary>
        /// Switch does brightness.
        /// </summary>
        Brightness = 1 << 1,
    }
}
