using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using libCecCore;

namespace Threax.Home.LibCec.Services
{
    public interface ICecManagerService : IDisposable
    {
        Task<string> GetName(CecLogicalAddress address);
        Task<CecPowerStatus> GetPower(CecLogicalAddress address);
        Task<CecVendorId> GetVendor(CecLogicalAddress address);
        Task Reconnect();
        Task<List<CecLogicalAddress>> Scan();
        Task SetHdmiPort(CecLogicalAddress device, byte port);
        Task SendHdmiPortChanged(byte port);
        Task SetOn(CecLogicalAddress address);
        Task SetStandby(CecLogicalAddress address);
        Task Start();
        Task Stop();
        Task<bool> SendKeypress(CecLogicalAddress iDestination, CecControlCode key, bool bWait);
        Task<bool> SendKeyRelease(CecLogicalAddress iDestination, bool bWait);
    }
}