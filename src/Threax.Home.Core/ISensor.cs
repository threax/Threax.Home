using System;

namespace Threax.Home.Core
{
    public interface ISensor
    {
        /// <summary>
        /// Which type of system the switch belongs to. (Hue, ZWave, etc.)
        /// </summary>
        String Subsystem { get; set; }

        /// <summary>
        /// A logical hardware grouping for the switch.
        /// </summary>
        String Bridge { get; set; }

        /// <summary>
        /// The id of the switch.
        /// </summary>
        String Id { get; set; }

        float? TempValue { get; set; }

        Units? TempUnits { get; set; }

        float? LightValue { get; set; }

        Units? LightUnits { get; set; }

        float? HumidityValue { get; set; }

        Units? HumidityUnits { get; set; }

        float? UvValue { get; set; }

        Units? UvUnits { get; set; }
    }
}
