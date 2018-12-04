using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libCecCore
{
    [StructLayout(LayoutKind.Sequential)]
    struct COPYDATASTRUCT
    {
        public IntPtr dwData;    // Any value the sender chooses.  Perhaps its main window handle?
        public int cbData;       // The count of bytes in the message.
        public IntPtr lpData;    // The address of the message.
    }

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

    public class WinLirc
    {
        public unsafe void SendMessage(String message)
        {
            var winName = "WinLirc";
            var otherWindow = FindWindow(null, winName);
            if (otherWindow == IntPtr.Zero)
            {
                throw new InvalidOperationException($"Cannot find {winName}");
            }

            var cpd = new COPYDATASTRUCT();
            cpd.dwData = IntPtr.Zero;
            cpd.cbData = message.Length + 1;
            using (var pMessage = new HGlobalHelper(Marshal.StringToHGlobalAnsi(message)))
            {
                cpd.lpData = pMessage.Ptr;
                using (var pObj = new HGlobalHelper(Marshal.AllocHGlobal(sizeof(COPYDATASTRUCT))))
                {
                    Marshal.StructureToPtr(cpd, pObj.Ptr, true);
                    var copyDataResult = SendMessageA(otherWindow, WM_COPYDATA, /*(WPARAM)hInstance*/IntPtr.Zero, pObj.Ptr);
                }
            }
        }

        const int WM_COPYDATA = 0x004A;

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessageA(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
}
