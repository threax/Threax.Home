using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.SwitchGroups.Database
{
    public class SwitchGroup
    {
        public int SwitchGroupId { get; set; }

        public List<SubSwitch> SubSwitches { get; set; }
    }
}
