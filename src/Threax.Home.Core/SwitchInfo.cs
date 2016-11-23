using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// Information about a switch.
    /// </summary>
    public class SwitchInfo<T>
    {
        /// <summary>
        /// The id of the switch.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// The display name for the switch. This will never be used for any logic.
        /// </summary>
        public String DisplayName { get; set; }

        /// <summary>
        /// The positions the switch can be in.
        /// </summary>
        public List<String> Positions { get; set; }

        /// <summary>
        /// A list of extra features a switch provides.
        /// </summary>
        public SwitchFeatures SwitchFeatures { get; set; }
    }
}
