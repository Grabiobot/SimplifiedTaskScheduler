using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedTaskScheduler.GUI
{
    class SettingsManager
    {
        public static UserSettings CurrentSettings { get; set; }
        public static void SaveSettings(UserSettings settings)
        {
            Properties.Settings.Default.StartWithWindows = settings.StartWithWindows;
            Properties.Settings.Default.ShowProgressNotifications = settings.ShowProgressNotifications;
            Properties.Settings.Default.Save();
        }
        public static UserSettings ReadSettings()
        {
            //Properties.Settings.Default.Reload();
            UserSettings settings = new UserSettings()
            {
                StartWithWindows = Properties.Settings.Default.StartWithWindows,
                ShowProgressNotifications = Properties.Settings.Default.ShowProgressNotifications
            };

            return settings;
        }
        public static void ApplyStartWithWindows(bool startWithWindows)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string product = fvi.ProductName;
            string name = fvi.ProductName;
            string value = System.Reflection.Assembly.GetEntryAssembly().Location;
            bool isSetToStartWithWindows = Utilities.WindowsStart.IsSet(Microsoft.Win32.Registry.CurrentUser, name, value);
            if (startWithWindows == isSetToStartWithWindows) return;
            if (!isSetToStartWithWindows)
            {
                isSetToStartWithWindows = !Utilities.WindowsStart.AddRegistryValue(Microsoft.Win32.Registry.CurrentUser, name, value);
            }
            else
            {
                Utilities.WindowsStart.DeleteRegistryValue(Microsoft.Win32.Registry.CurrentUser, name, value);
            }
        }
    }
}
