// I:\Clear-Cache-Icons\ClearCacheIcons\Logger.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClearCacheIcons
{
    public static class Logger
    {
        private static RichTextBox? _logTextBox; // Hacerlo anulable

        public static void Initialize(RichTextBox logTextBox)
        {
            _logTextBox = logTextBox;
        }

        public static void Log(string message, bool isError = false)
        {
            if (_logTextBox == null) return; // Comprobación de nulidad

            if (_logTextBox.InvokeRequired)
            {
                _logTextBox.Invoke(new Action(() => Log(message, isError)));
                return;
            }

            _logTextBox.SelectionColor = Color.White;
            _logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] ");
            if (isError)
            {
                _logTextBox.SelectionColor = Color.Red;
            }
            else
            {
                _logTextBox.SelectionColor = Color.White;
            }
            _logTextBox.AppendText(message + Environment.NewLine);
            _logTextBox.ScrollToCaret();
        }
    }
}
