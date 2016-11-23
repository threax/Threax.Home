using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// An interface for SwitchControllers to make sure they conform.
    /// This one supports scopes.
    /// </summary>
    /// <typeparam name="TPosition">The type of the SwitchPosition, can be SwitchPosition</typeparam>
    /// <typeparam name="Tid">The type of the switch id</typeparam>
    /// <typeparam name="TScope">The type of the scope argument.</typeparam>
    public interface ISwitchController<TPosition, Tid, TScope>
        where TPosition : SwitchPosition<Tid>
    {
        /// <summary>
        /// Set the switch position for the given color switch on the given bridge.
        /// </summary>
        /// <param name="scope">The scope for the switch.</param>
        /// <param name="settings">The position to apply.</param>
        /// <returns>void</returns>
        Task SetPosition(TScope scope, IEnumerable<TPosition> settings);

        /// <summary>
        /// Get the position of the switch.
        /// </summary>
        /// <param name="scope">The scope for the switch.</param>
        /// <param name="ids">The id of the switch.</param>
        /// <returns>The switch position status.</returns>
        Task<IEnumerable<TPosition>> GetPosition(TScope scope, IEnumerable<Tid> ids);

        /// <summary>
        /// Get a list of all the color switches supported by this api on the given bridge.
        /// </summary>
        /// <param name="scope">The scope for the switch.</param>
        /// <returns>A list of all switches in the scope.</returns>
        Task<IEnumerable<SwitchInfo<Tid>>> List(TScope scope);
    }
}
