using libCecCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threax.Home.LibCec.Services
{
    public class CecManagerService : ICecManagerService
    {
        private SemaphoreSlim readLock = new SemaphoreSlim(1, 1);
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
            return await GetReadLock(() => cecManager.GetName(address));
        }

        public async Task<CecPowerStatus> GetPower(CecLogicalAddress address)
        {
            return await GetReadLock(() => cecManager.GetPower(address));
        }

        public async Task<CecVendorId> GetVendor(CecLogicalAddress address)
        {
            return await GetReadLock(() => cecManager.GetVendor(address));
        }

        public async Task Reconnect()
        {
            await GetReadLock(() => cecManager.Reconnect());
        }

        public async Task<List<CecLogicalAddress>> Scan()
        {
            return await GetReadLock(() => cecManager.Scan());
        }

        public async Task SetHdmiPort(CecLogicalAddress device, byte port)
        {
            await GetReadLock(() => cecManager.SetHdmiPort(device, port));
        }

        public async Task SetOn(CecLogicalAddress address)
        {
            await GetReadLock(() => cecManager.SetOn(address));
        }

        public async Task SetStandby(CecLogicalAddress address)
        {
            await GetReadLock(() => cecManager.SetStandby(address));
        }

        public async Task Start()
        {
            await GetReadLock(() => cecManager.Start());
        }

        public async Task Stop()
        {
            await GetReadLock(() => cecManager.Stop());
        }

        private async Task GetReadLock(Action cb)
        {
            try
            {
                await readLock.WaitAsync();
                cb();
            }
            finally
            {
                readLock.Release();
            }
        }


        private async Task<T> GetReadLock<T>(Func<T> cb)
        {
            try
            {
                await readLock.WaitAsync();
                return cb();
            }
            finally
            {
                readLock.Release();
            }
        }

    }
}
