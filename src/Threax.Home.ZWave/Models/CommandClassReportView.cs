using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZWave.Channel;

namespace Threax.Home.ZWave.Models
{
    public class CommandClassReportView
    {
        public CommandClass Class { get; set; }
        public byte NodeId { get; internal set; }
        public byte Version { get; set; }
    }
}
