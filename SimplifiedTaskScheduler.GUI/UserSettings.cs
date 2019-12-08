
namespace SimplifiedTaskScheduler.GUI
{
    public class UserSettings
    {
        public bool StartWithWindows { get;set;}
        public bool ShowProgressNotifications { get; set; }
        public bool KeepNotificationsOnTop { get; set; }
        public string ActiveFolder { get; set; }
        public int DelayedStartOfTasks { get; set; }
    }
}
