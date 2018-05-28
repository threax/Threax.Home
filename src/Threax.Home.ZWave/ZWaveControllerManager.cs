using System;
using System.Collections.Generic;
using System.Text;
using ZWave;

namespace Threax.Home.ZWave
{
    public class ZWaveControllerManager : IDisposable, IZWaveControllerManager
    {
        private ZWaveController controller;

        public ZWaveControllerManager(ZWaveConfig options)
        {
            controller = new ZWaveController(options.ComPort);
            controller.Open();
        }

        public void Dispose()
        {
            controller.Close();
        }

        public ZWaveController Controller => controller;
    }
}
