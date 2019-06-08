using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiGameBoi.Utils
{
    /// <summary>
    /// Utility class to find window pointers and set them to the foreground.
    /// </summary>
    internal class WindowUtil
    {
        /// <summary>
        /// Finds a window by its title
        /// </summary>
        /// <param name="wName"></param>
        /// <returns></returns>
        public static IntPtr FindWindowByTitle(string wName)
        {
            /*IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains(wName))
                    hWnd = pList.MainWindowHandle;
                           
            return hWnd;*/

            return FindWindow(null, wName);
        }

        /// <summary>
        /// Brings a window to the foreground.
        /// </summary>
        /// <param name="processName"></param>
        public static void SetForeground(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if(processes != null && processes.Length > 0)
                SetForegroundWindow(processes[0].MainWindowHandle);
        }

        /// <summary>
        /// Finds a window by its title and brings it to the foreground.
        /// </summary>
        /// <param name="title"></param>
        public static void SetForegroundByTitle(string title)
        {
            try
            {
                SetForegroundWindow(FindWindowByTitle(title));
            }
            catch { }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
