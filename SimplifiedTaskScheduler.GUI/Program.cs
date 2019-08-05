using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "Grabiobot's " + "Simplified Task Scheduler"; 
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                MessageBox.Show("Another instance is already running!", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserSettings settings = SettingsManager.ReadSettings();
            SettingsManager.CurrentSettings = settings;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsManager.ApplyStartWithWindows(SettingsManager.CurrentSettings.StartWithWindows);
            //Application.Run(new FormTasksList());
            Application.Run(new FormMain());
            SettingsManager.SaveSettings(SettingsManager.CurrentSettings);
        }


    }
}
