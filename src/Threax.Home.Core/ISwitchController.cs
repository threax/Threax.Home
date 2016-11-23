using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// An interface for SwitchControllers to make sure they conform.
    /// </summary>
    /// <typeparam name="TPosition">The type of the SwitchPosition, can be SwitchPosition</typeparam>
    /// <typeparam name="Tid">The type of the switch id</typeparam>
    public interface ISwitchController<TPosition, Tid>
        where TPosition : SwitchPosition
    {
        /// <summary>
        /// Set the switch position for the given color switch on the given bridge.
        /// </summary>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        Task SetPosition(IEnumerable<TPosition> settings);

        /// <summary>
        /// Get the position of the switch.
        /// </summary>
        /// <param name="ids">The id of the switch.</param>
        /// <returns>The switch position status.</returns>
        Task<IEnumerable<TPosition>> GetPosition(IEnumerable<Tid> ids);

        /// <summary>
        /// Get a list of all the color switches supported by this api on the given bridge.
        /// </summary>
        /// <returns>A list of all the switches.</returns>
        Task<IEnumerable<SwitchInfo>> List();
    }
}
