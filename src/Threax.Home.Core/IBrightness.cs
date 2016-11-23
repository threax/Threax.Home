using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// Implementors have a Brightness property.
    /// </summary>
    public interface IBrightness
    {
        /// <summary>
        /// The brightness from 0 to 255. Null to not modify.
        /// </summary>
        byte? Brightness { get; set; }
    }
}
