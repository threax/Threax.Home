﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// A position of a switch, since positions are named, you can have unlimited positions per switch.
    /// </summary>
    public class SwitchPosition
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SwitchPosition()
        {
        }

        /// <summary>
        /// The id of the switch to set.
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// The value to set the switch position to.
        /// </summary>
        public String Value { get; set; }
    }
}
