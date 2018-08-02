using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MfiSharp
{
    /// <summary>
    /// This class represents a setting on a relay.
    /// </summary>
    public class RelaySetting
    {
        /// <summary>
        /// Create a relay setting. Indices start at 1.
        /// </summary>
        /// <param name="index">The index of the relay. Starts at 1.</param>
        /// <param name="on">True for on.</param>
        public RelaySetting(int index, bool on)
        {
            this.Index = index;
            this.On = on;
        }

        /// <summary>
        /// Internal constructor to recover 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="client"></param>
        internal RelaySetting(int index, SshClient client)
        {
            this.Index = index;
            var command = client.RunCommand(String.Format("cat /proc/power/relay{0}", Index));
            On = command.Result.Contains("1");
        }

        /// <summary>
        /// True to turn relay on.
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// The index of the relay, starts at 1.
        /// </summary>
        public int Index { get; private set; }

        internal void execute(SshClient client)
        {
            client.RunCommand(String.Format("echo {0} > /proc/power/relay{1}", On ? "1" : "0", Index));
        }
    }
}
