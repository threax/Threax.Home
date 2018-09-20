using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;

namespace Threax.Home.ZWave.Models
{
    /// <summary>
    /// The switch positions.
    /// </summary>
    /// <remarks>
    /// These are lowercase for consistency.
    /// </remarks>
    public enum Switch3SwitchPosition
    {
        off,
        low,
        medium,
        high
    }
}
