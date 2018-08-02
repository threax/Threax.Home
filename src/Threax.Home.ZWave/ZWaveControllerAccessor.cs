using System;
using System.Collections.Generic;
using System.Text;
using ZWave;

namespace Threax.Home.ZWave
{
    public class ZWaveControllerAccessor : IDisposable, IZWaveControllerAccessor
    {
        private ZWaveController controller;

        public ZWaveControllerAccessor(ZWaveConfig options)
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
