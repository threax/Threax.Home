using System;
using System.Collections.Generic;

namespace libCecCore
{
    public interface ICecManager : IDisposable
    {
        string GetName(CecLogicalAddress address);
        CecPowerStatus GetPower(CecLogicalAddress address);
        CecVendorId GetVendor(CecLogicalAddress address);
        void Reconnect();
        List<CecLogicalAddress> Scan();
        void SetHdmiPort(CecLogicalAddress device, byte port);
        void SetOn(CecLogicalAddress address);
        void SetStandby(CecLogicalAddress address);
        void Start();
        void Stop();
    }
}