using System;
using System.Threading;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    internal static class Program
    {
        private static Mutex mutex = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string product = fvi.ProductName;
            string appName = product + " v." + version;

            mutex = new Mutex(true, appName, out bool createdNew);

            if (!createdNew)
            {
                //application is already running! Exiting the application
                MessageBox.Show("Another instance is already running!", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserSettings settings = SettingsManager.ReadSettings();
            SettingsManager.CurrentSettings = settings;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsManager.ApplyStartWithWindows(SettingsManager.CurrentSettings.StartWithWindows);
            Application.Run(new FormMain());
            SettingsManager.SaveSettings(SettingsManager.CurrentSettings);
        }
    }
}
