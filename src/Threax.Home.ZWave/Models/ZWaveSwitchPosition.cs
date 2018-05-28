using Halcyon.HAL.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;
using Threax.Home.ZWave.Controllers;

namespace Threax.Home.ZWave.Models
{
    public enum Switch3SwitchPosition
    {
        Off,
        Low,
        Medium,
        High
    }
    
    public class ZWaveSwitchPosition
    {
        public int Id { get; set; }
        public Switch3SwitchPosition Value { get; set; }
    }
}
