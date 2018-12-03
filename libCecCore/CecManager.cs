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

        void Start()
        {
            CecManager_Start(ptr);
        }

        void Stop()
        {
            CecManager_Stop(ptr);
        }

        /// <summary>
        /// Scan the CEC bus and display device info.
        /// </summary>
        public IEnumerable<DeviceInfo> Scan()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the power status of the specified device.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public cec_power_status GetPower(int address)
        {
            return CecManager_GetPower(ptr, address);
        }

        public String GetName(int address)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the device with the given address to on.
        /// </summary>
        public void SetOn(int address)
        {
            CecManager_SetOn(ptr, address);
        }

        /// <summary>
        /// Set the device with the given address to standby or off.
        /// </summary>
        public void SetStandby(int address)
        {
            CecManager_SetStandby(ptr, address);
        }

        /// <summary>
        /// Set the hdmi port number of the cec adapter.
        /// </summary>
        /// <param name="port"></param>
        public void SetHdmiPort(int device, byte port)
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

        #region PInvoke

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CecManager_Create();

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Delete(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Start(IntPtr ptr);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Stop(IntPtr ptr);

        //void CecManager_Scan();

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern cec_power_status CecManager_GetPower(IntPtr ptr, int address);

        //String CecManager_GetName(IntPtr ptr, int address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetOn(IntPtr ptr, int address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetStandby(IntPtr ptr, int address);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_SetHdmiPort(IntPtr ptr, int device, byte port);

        [DllImport(LibraryInfo.Name, CallingConvention = CallingConvention.Cdecl)]
        private static extern void CecManager_Reconnect(IntPtr ptr);

        #endregion
    }
}
