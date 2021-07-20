using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace libCecCore
{
    public class CecManager : ICecManager
    {
        private IntPtr ptr;

        public CecManager(int hdmiPort, String port)
        {
            ptr = CecManager_Create(hdmiPort, port);
        }

        /// <summary>
        /// Dispose the object, also calls stop.
        /// </summary>
        public void Dispose()
        {
            if (ptr != IntPtr.Zero)
            {
                Stop();
                CecManager_Delete(ptr);
                ptr = IntPtr.Zero;
            }
        }

        public void Start()
        {
            CecManager_Start(ptr);
        }

        public void Stop()
        {
            CecManager_Stop(ptr);
        }

        /// <summary>
        /// Scan the CEC bus and get active devices.
        /// </summary>
        public List<CecLogicalAddress> Scan()
        {
            List<CecLogicalAddress> devices = new List<CecLogicalAddress>(10);
            ScanCallback cb = i => devices.Add(i);
            CecManager_Scan(ptr, cb);
            return devices;
        }

        /// <summary>
        /// Get the power status of the specified device.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public CecPowerStatus GetPower(CecLogicalAddress address)
        {
            return CecManager_GetPower(ptr, address);
        }

        /// <summary>
        /// Get the name of a port. Does not work.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public String GetName(CecLogicalAddress address)
        {
            //throw new InvalidOperationException("This does not work");
            String result = null;
            StringRetrieverCallback callback = n => result = n;
            CecManager_GetName(ptr, callback, address);
            return result;
        }

        /// <summary>
        /// Set the device with the given address to on.
        /// </summary>
        public void SetOn(CecLogicalAddress address)
        {
            CecManager_SetOn(ptr, address);
        }

        /// <summary>
        /// Set the device with the given address to standby or off.
        /// </summary>
        public void SetStandby(CecLogicalAddress address)
        {
            CecManager_SetStandby(ptr, address);
        }

        /// <summary>
        /// Set the hdmi port number of the cec adapter.
        /// </summary>
        /// <param name="port"></param>
        public void SetHdmiPort(CecLogicalAddress device, byte port)
        {
            CecManager_SetHdmiPort(ptr, device, port);
        }

        /// <summary>
        /// Reconnect to the CEC adapter.
        /// </summary>
        public void Reconnect()
        {
            CecManager_Reconnect(ptr);
        }

        public CecVendorId GetVendor(CecLogicalAddress address)
        {
            return CecManager_GetVendor(ptr, address);
        }

        public bool SendKeypress(CecLogicalAddress iDestination, CecControlCode key, bool bWait)
        {
            return CecManager_SendKeypress(ptr, iDestination, key, bWait);
        }

        public bool SendKeyRelease(CecLogicalAddress iDestination, bool bWait)
        {
            return CecManager_SendKeyRelease(ptr, iDestination, bWait);
        }

        #region PInvoke

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StringRetrieverCallback(String value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void ScanCallback(CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CecManager_Create(int hdmiPort, String port);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Delete(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Start(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Stop(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Scan(IntPtr ptr, ScanCallback cb);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern CecPowerStatus CecManager_GetPower(IntPtr ptr, CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_GetName(IntPtr ptr, StringRetrieverCallback cb, CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetOn(IntPtr ptr, CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetStandby(IntPtr ptr, CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetHdmiPort(IntPtr ptr, CecLogicalAddress device, byte port);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Reconnect(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern CecVendorId CecManager_GetVendor(IntPtr ptr, CecLogicalAddress address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool CecManager_SendKeypress(IntPtr ptr, CecLogicalAddress iDestination, CecControlCode key, [MarshalAs(UnmanagedType.I1)] bool bWait);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool CecManager_SendKeyRelease(IntPtr ptr, CecLogicalAddress iDestination, [MarshalAs(UnmanagedType.I1)] bool bWait);

        #endregion
    }
}
