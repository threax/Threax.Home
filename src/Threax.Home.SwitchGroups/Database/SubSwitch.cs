using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Home.SwitchGroups.Database
{
    public class SubSwitch
    {
        public int SubSwitchId { get; set; }

        public String SwitchId { get; set; }

        public int SwitchGroupId { get; set; }
        public SwitchGroup SwitchGroup { get; set; }

        public int SwitchSourceId { get; set; }
        public SwitchSource SwitchSource { get; set; }
    }
}
