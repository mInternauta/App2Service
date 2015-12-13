using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace App2Service.Logic
{
    public static class Win32Utils
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        //I'd double check this constant, just in case
        static uint WM_QUTI = 0x12;

        public static void Quit(IntPtr hWindow)
        {
            try
            {
                SendMessage(hWindow, WM_QUTI, IntPtr.Zero, IntPtr.Zero);
            }
            catch { }
        }
    }
}
