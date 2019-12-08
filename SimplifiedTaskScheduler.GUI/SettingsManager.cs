using System;

namespace SimplifiedTaskScheduler.GUI
{
    internal static class SettingsManager
    {
        public static UserSettings CurrentSettings { get; set; }

        public static void SaveSettings(UserSettings settings)
        {
            Properties.Settings.Default.StartWithWindows = settings.StartWithWindows;
            Properties.Settings.Default.ShowProgressNotifications = settings.ShowProgressNotifications;
            Properties.Settings.Default.KeepNotificationsOnTop = settings.KeepNotificationsOnTop;
            Properties.Settings.Default.ActiveFolder = settings.ActiveFolder;
            Properties.Settings.Default.DelayedStartOfTasks = settings.DelayedStartOfTasks;
            Properties.Settings.Default.Save();
        }

        public static UserSettings ReadSettings()
        {
            Properties.Settings.Default.Reload();
            UserSettings settings = new UserSettings()
            {
                StartWithWindows = Properties.Settings.Default.StartWithWindows,
                ShowProgressNotifications = Properties.Settings.Default.ShowProgressNotifications,
                KeepNotificationsOnTop = Properties.Settings.Default.KeepNotificationsOnTop,
                ActiveFolder = Properties.Settings.Default.ActiveFolder,
                DelayedStartOfTasks = Properties.Settings.Default.DelayedStartOfTasks
            };

            return settings;
        }

        public static void ApplyStartWithWindows(bool startWithWindows)
        {
#if DEBUG
#else
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string name = fvi.ProductName;
            string value = System.Reflection.Assembly.GetEntryAssembly().Location;
            bool isSetToStartWithWindows = Utilities.WindowsStart.IsSet(Microsoft.Win32.Registry.CurrentUser, name, value);
            if (startWithWindows == isSetToStartWithWindows) return;
            if (!isSetToStartWithWindows)
            {
                Utilities.WindowsStart.AddRegistryValue(Microsoft.Win32.Registry.CurrentUser, name, value);
            }
            else
            {
                Utilities.WindowsStart.DeleteRegistryValue(Microsoft.Win32.Registry.CurrentUser, name, value);
            }
#endif
        }
    }
}
