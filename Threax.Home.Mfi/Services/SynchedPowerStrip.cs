using MfiSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.MFi.Services
{
    /// <summary>
    /// A power strip client that will only allow one connection to the power strip at a time.
    /// </summary>
    public class SynchedPowerStrip : IPowerStrip
    {
        private PowerStrip powerStrip;
        private SemaphoreSlimLock locker = new SemaphoreSlimLock();

        /// <summary>
        /// Constructor
        /// </summary>
        public SynchedPowerStrip(PowerStrip powerStrip)
        {
            this.powerStrip = powerStrip;
        }

        /// <summary>
        /// Clean up the locker.
        /// </summary>
        public void Dispose()
        {
            locker.Dispose();
        }

        /// <summary>
        /// Set the power relay to the specified settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task ApplySettings(IEnumerable<RelaySetting> settings)
        {
            await locker.Run(async () =>
            {
                //Run on background thread, hold locker until done
                await Task.Run(() =>
                {
                    powerStrip.SetSettings(settings);
                    powerStrip.ApplySettings();
                });
            });
        }

        /// <summary>
        /// Get the current settings of the power relay.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RelaySetting>> GetSettings()
        {
            return await locker.Run(async () =>
            {
                IEnumerable<RelaySetting> settings = null;
                //Run on background thread, hold locker until done
                await Task.Run(() =>
                {
                    powerStrip.LoadCurrentSettings();
                    settings = powerStrip.Settings.ToList();
                    powerStrip.ClearSettings();
                });
                return settings;
            });
        }
    }
}
