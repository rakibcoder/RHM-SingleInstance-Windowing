using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace RHM.SingleInstance.Windowing
{
    /// <summary>
    /// Contains native Windows API methods for window management.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Brings the specified window to the foreground.
        /// </summary>
        /// <param name="hWnd">Handle of the window to bring to foreground.</param>
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Sets the specified window's show state (e.g., hide, maximize, restore).
        /// </summary>
        /// <param name="hWnd">Handle of the window.</param>
        /// <param name="nCmdShow">Show state flag.</param>
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        internal const int SW_RESTORE = 9;

        /// <summary>
        /// Activates the main window of the specified process by restoring it (if minimized)
        /// and bringing it to the foreground.
        /// </summary>
        /// <param name="process">The process whose main window should be activated.</param>
        public static void ActivateWindow(Process process)
        {
            if (process == null || process.MainWindowHandle == IntPtr.Zero)
                return;

            ShowWindow(process.MainWindowHandle, SW_RESTORE);
            SetForegroundWindow(process.MainWindowHandle);
        }
    }
}
