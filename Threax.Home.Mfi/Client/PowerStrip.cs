using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Threax.Home.MFi;

namespace MfiSharp
{
    /// <summary>
    /// This class is a client to a power strip.
    /// </summary>
    public class PowerStrip
    {
        private String host;
        private String user;
        private String pass;

        private List<RelaySetting> settings = new List<RelaySetting>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="config">The config.</param>
        public PowerStrip(PowerStripConfig config)
        {
            this.host = config.Host;
            this.user = config.User;
            this.pass = config.Pass;
            this.RelayCount = config.RelayCount;
        }

        /// <summary>
        /// Add a setting for a specific relay.
        /// </summary>
        /// <param name="setting">The setting to apply.</param>
        public void AddSetting(RelaySetting setting)
        {
            int indexTest = setting.Index - 1;
            if(indexTest >= RelayCount || indexTest < 0)
            {
                throw new IndexOutOfRangeException(String.Format("Relay setting index out of range '{0}'", setting.Index));
            }
            settings.Add(setting);
        }

        /// <summary>
        /// Set the settings to the exact settings in the IEnumerable. Must still be within indexes of power strip.
        /// </summary>
        /// <param name="settings"></param>
        public void SetSettings(IEnumerable<RelaySetting> settings)
        {
            ClearSettings();
            foreach(var setting in settings)
            {
                AddSetting(setting);
            }
        }

        /// <summary>
        /// Apply all current settings and clear the settings list.
        /// You do not have to set a setting for all relays, only
        /// existing relays will change.
        /// </summary>
        public void ApplySettings()
        {
            using (var client = new SshClient(host, user, pass))
            {
                client.Connect();
                foreach(var setting in settings)
                {
                    setting.execute(client);
                }
                client.Disconnect();
            }
            settings.Clear();
        }

        /// <summary>
        /// Get the current settings of all relays on the power strip.
        /// </summary>
        public void LoadCurrentSettings()
        {
            settings.Clear();
            using (var client = new SshClient(host, user, pass))
            {
                client.Connect();
                for (int i = 0; i < RelayCount; ++i)
                {
                    settings.Add(new RelaySetting(i + 1, client));
                }
                client.Disconnect();
            }
        }

        /// <summary>
        /// Clear all settings in memory.
        /// </summary>
        public void ClearSettings()
        {
            settings.Clear();
        }

        /// <summary>
        /// The current settings loaded into the client. If you called LoadCurrentSettings first
        /// these will be the values from the power strip.
        /// </summary>
        public IEnumerable<RelaySetting> Settings
        {
            get
            {
                return settings.AsReadOnly();
            }
        }

        /// <summary>
        /// The total count of all relays on this power strip.
        /// </summary>
        public int RelayCount { get; private set; }
    }
}
