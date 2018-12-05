using libCecCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threax.Home.Core;

namespace Threax.Home.LibCec.Services
{
    public class CecManagerService : ICecManagerService
    {
        private SemaphoreSlimLock readLock = new SemaphoreSlimLock();
        private ICecManager cecManager;

        public CecManagerService(ICecManager cecManager)
        {
            this.cecManager = cecManager;
        }

        public void Dispose()
        {
            readLock.Dispose();
        }

        public async Task<string> GetName(CecLogicalAddress address)
        {
            return await readLock.Run(() => cecManager.GetName(address));
        }

        public async Task<CecPowerStatus> GetPower(CecLogicalAddress address)
        {
            return await readLock.Run(() => cecManager.GetPower(address));
        }

        public async Task<CecVendorId> GetVendor(CecLogicalAddress address)
        {
            return await readLock.Run(() => cecManager.GetVendor(address));
        }

        public async Task Reconnect()
        {
            await readLock.Run(() => cecManager.Reconnect());
        }

        public async Task<List<CecLogicalAddress>> Scan()
        {
            return await readLock.Run(() => cecManager.Scan());
        }

        public async Task SetHdmiPort(CecLogicalAddress device, byte port)
        {
            await readLock.Run(() => cecManager.SetHdmiPort(device, port));
        }

        public async Task SetOn(CecLogicalAddress address)
        {
            await readLock.Run(() => cecManager.SetOn(address));
        }

        public async Task SetStandby(CecLogicalAddress address)
        {
            await readLock.Run(() => cecManager.SetStandby(address));
        }

        public async Task Start()
        {
            await readLock.Run(() => cecManager.Start());
        }

        public async Task Stop()
        {
            await readLock.Run(() => cecManager.Stop());
        }

    }
}
