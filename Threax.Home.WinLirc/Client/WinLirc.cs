using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Threax.Home.WinLirc
{
    static class WinLirc
    {
        public static unsafe void SendMessage(String message)
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
                    var copyDataResult = SendMessageA(otherWindow, WM_COPYDATA, IntPtr.Zero, pObj.Ptr);
                }
            }
        }

        const int WM_COPYDATA = 0x004A;

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, String lpWindowName);
        [DllImport("user32.dll")]
        private static extern int SendMessageA(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    }
}
