using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Threax.Home.WinLirc
{
    class HGlobalHelper : IDisposable
    {
        private IntPtr hGlobal;

        public HGlobalHelper(IntPtr hGlobal)
        {
            this.hGlobal = hGlobal;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(this.hGlobal);
        }

        public IntPtr Ptr { get => hGlobal; }
    }
}
