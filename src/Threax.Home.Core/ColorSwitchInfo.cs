using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class ColorSwitchInfo
    {
        /// <summary>
        /// The name of the switch.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The display name for the switch. This will never be used for any logic.
        /// </summary>
        public String DisplayName { get; set; }
    }
}
