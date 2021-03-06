﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;
using Threax.Home.Core;

namespace Threax.Home.ModelSchemas
{
    //[RequireAuthorization(typeof(Roles), nameof(Roles.EditValues))]
    [AddNamespaces("using Threax.Home.Core;")]
    public abstract class Sensor : ICoreSensor
    {
        /// <summary>
        /// The name of the switch. Suitable for display.
        /// </summary>
        [Required]
        [MaxLength(450)]
        [UiOrder]
        public String Name { get; set; }

        /// <summary>
        /// Which type of system the switch belongs to. (Hue, ZWave, etc.)
        /// </summary>
        [Required]
        [MaxLength(450)]
        [UiOrder]
        public String Subsystem { get; set; }

        /// <summary>
        /// A logical hardware grouping for the switch.
        /// </summary>
        [Required]
        [MaxLength(450)]
        [UiOrder]
        public String Bridge { get; set; }

        /// <summary>
        /// The id of the switch.
        /// </summary>
        [Required]
        [MaxLength(450)]
        [UiOrder]
        public String Id { get; set; }

        [UiOrder]
        public double? TempValue { get; set; }

        [UiOrder]
        public Units? TempUnits { get; set; }

        [UiOrder]
        public double? LightValue { get; set; }

        [UiOrder]
        public Units? LightUnits { get; set; }

        [UiOrder]
        public double? HumidityValue { get; set; }

        [UiOrder]
        public Units? HumidityUnits { get; set; }

        [UiOrder]
        public double? UvValue { get; set; }

        [UiOrder]
        public Units? UvUnits { get; set; }
    }
}
