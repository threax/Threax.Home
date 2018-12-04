﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using libCecCore;

namespace Threax.Home.LibCec.Services
{
    public interface ICecManagerService : IDisposable
    {
        void Dispose();
        Task<string> GetName(CecLogicalAddress address);
        Task<CecPowerStatus> GetPower(CecLogicalAddress address);
        Task<CecVendorId> GetVendor(CecLogicalAddress address);
        Task Reconnect();
        Task<List<CecLogicalAddress>> Scan();
        Task SetHdmiPort(CecLogicalAddress device, byte port);
        Task SetOn(CecLogicalAddress address);
        Task SetStandby(CecLogicalAddress address);
        Task Start();
        Task Stop();
    }
}