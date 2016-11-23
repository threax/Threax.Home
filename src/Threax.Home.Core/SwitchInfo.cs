using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// Information about a switch.
    /// </summary>
    public class SwitchInfo
    {
        /// <summary>
        /// The name of the switch.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The positions the switch can be in.
        /// </summary>
        public List<String> Positions { get; set; }
    }
}
