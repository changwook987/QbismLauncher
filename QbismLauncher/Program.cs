using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using QbismLauncher.Forms;

namespace QbismLauncher
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var form = new LauncherForm();
            form.Show();
            Application.Run();
        }
    }
}