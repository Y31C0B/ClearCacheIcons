using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace ClearCacheIcons
{
    internal static class ExplorerController
    {
        private const int WM_CLOSE = 0x0010;

        [DllImport("user32.dll")]
        private static extern bool PostMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam
        );

        public static bool IsExplorerRunning()
        {
            return Process.GetProcessesByName("explorer").Any();
        }

        public static bool TryCloseExplorerGracefully(int timeoutMs = 5000)
        {
            var explorers = Process.GetProcessesByName("explorer");
            if (explorers.Length == 0)
                return true;

            foreach (var proc in explorers)
            {
                try
                {
                    if (proc.MainWindowHandle != IntPtr.Zero)
                        PostMessage(proc.MainWindowHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
                catch
                {
                    // Error recuperable
                }
            }

            return WaitForExplorerExit(timeoutMs);
        }

        public static bool ForceKillExplorer()
        {
            try
            {
                foreach (var proc in Process.GetProcessesByName("explorer"))
                {
                    try
                    {
                        proc.Kill(true);
                    }
                    catch
                    {
                        // Puede fallar en Windows moderno (normal)
                    }
                }

                return WaitForExplorerExit(10000); // Keep the 10-second timeout
            }
            catch
            {
                return false;
            }
        }

        private static bool WaitForExplorerExit(int timeoutMs)
        {
            int waited = 0;

            while (waited < timeoutMs)
            {
                if (!IsExplorerRunning())
                    return true;

                Thread.Sleep(250);
                waited += 250;
            }

            return false;
        }

        public static void RestartExplorer()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    UseShellExecute = true
                });
            }
            catch
            {
                // Si falla, Windows normalmente lo relanza solo
            }
        }
    }
}