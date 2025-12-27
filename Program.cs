using System;
using System.Windows.Forms;
using System.Threading; // Necesario para Mutex

namespace ClearCacheIcons;

static class Program
{
    private const string AppName = "ClearCacheIcons_AppMutex";
    private static Mutex mutex = new Mutex(true, AppName);

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        if (!mutex.WaitOne(TimeSpan.Zero, true))
        {
            // Si el mutex ya está tomado, significa que otra instancia está corriendo.
            using (var form = new CustomMessageBoxForm("Clear Cache Icons ya se está ejecutando.", "Aplicación en ejecución"))
            {
                form.ShowDialog();
            }
            return;
        }

        try
        {
            Console.WriteLine("Application Main method started."); // Debug log
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2); // Habilitar escalado DPI por monitor
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
            Console.WriteLine("Application.Run completed."); // Debug log
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unhandled exception occurred: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show($"An unhandled exception occurred: {ex.Message}\n\n{ex.StackTrace}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            mutex.ReleaseMutex(); // Liberar el mutex al cerrar la aplicación
        }
    }
}

