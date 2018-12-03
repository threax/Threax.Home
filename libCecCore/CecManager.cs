using System;
using System.Collections;
using System.Collections.Generic;

namespace libCecCore
{
    public class CecManager : IDisposable
    {
        public CecManager()
        {

        }

        public void Dispose()
        {
            
        }

        void Start()
        {

        }

        void Stop()
        {

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
        public bool GetPower(int address)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the device with the given address to standby or off.
        /// </summary>
        public void SetStandby(int address)
        {

        }

        /// <summary>
        /// Set the hdmi port number of the cec adapter.
        /// </summary>
        /// <param name="port"></param>
        public void SetHdmiPort(int device, int port)
        {

        }

        /// <summary>
        /// Reconnect to the CEC adapter.
        /// </summary>
        public void Reconnect()
        {

        }
    }
}
