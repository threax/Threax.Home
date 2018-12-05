using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Threax.Home.WinLirc
{
    [StructLayout(LayoutKind.Sequential)]
    struct COPYDATASTRUCT
    {
        public IntPtr dwData;    // Any value the sender chooses.  Perhaps its main window handle?
        public int cbData;       // The count of bytes in the message.
        public IntPtr lpData;    // The address of the message.
    }
}
