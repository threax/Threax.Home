using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace libCecCore
{
    public class CecManager : IDisposable
    {
        private IntPtr ptr;

        public CecManager()
        {
            ptr = CecManager_Create();
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
        public List<cec_logical_address> Scan()
        {
            List<cec_logical_address> devices = new List<cec_logical_address>(10);
            ScanCallback cb = i => devices.Add(i);
            CecManager_Scan(ptr, cb);
            return devices;
        }

        /// <summary>
        /// Get the power status of the specified device.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public cec_power_status GetPower(cec_logical_address address)
        {
            return CecManager_GetPower(ptr, address);
        }

        /// <summary>
        /// Get the name of a port.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public String GetName(cec_logical_address address)
        {
            throw new InvalidOperationException("This does not work");
            String result = null;
            StringRetrieverCallback callback = n => result = n;
            CecManager_GetName(ptr, callback, address);
            return result;
        }

        /// <summary>
        /// Set the device with the given address to on.
        /// </summary>
        public void SetOn(cec_logical_address address)
        {
            CecManager_SetOn(ptr, address);
        }

        /// <summary>
        /// Set the device with the given address to standby or off.
        /// </summary>
        public void SetStandby(cec_logical_address address)
        {
            CecManager_SetStandby(ptr, address);
        }

        /// <summary>
        /// Set the hdmi port number of the cec adapter.
        /// </summary>
        /// <param name="port"></param>
        public void SetHdmiPort(cec_logical_address device, byte port)
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

        public cec_vendor_id GetVendor(cec_logical_address address)
        {
            return CecManager_GetVendor(ptr, address);
        }

        #region PInvoke

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StringRetrieverCallback(String value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void ScanCallback(cec_logical_address address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CecManager_Create();

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Delete(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Start(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Stop(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Scan(IntPtr ptr, ScanCallback cb);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern cec_power_status CecManager_GetPower(IntPtr ptr, cec_logical_address address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_GetName(IntPtr ptr, StringRetrieverCallback cb, cec_logical_address address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetOn(IntPtr ptr, cec_logical_address address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetStandby(IntPtr ptr, cec_logical_address address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetHdmiPort(IntPtr ptr, cec_logical_address device, byte port);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Reconnect(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern cec_vendor_id CecManager_GetVendor(IntPtr ptr, cec_logical_address address);

        #endregion
    }
}
