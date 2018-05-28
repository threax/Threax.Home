using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Home.Core
{
    [HalModel]
    public class SensorDataView
    {
        public float Value { get; set; }

        public Units Units { get; set; }
    }
}
