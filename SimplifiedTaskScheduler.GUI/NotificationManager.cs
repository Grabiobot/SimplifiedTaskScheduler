using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public sealed class NotificationManager
    {
        public static NotificationManager Instance { get; } = new NotificationManager();

        private NotificationManager()
        {
        }

        private FormNotification _frm = null;
        private readonly object _locker = new object();
        private DateTime _lastAccepted = DateTime.Now;

        public void ShowNotification(string message, string taskId, string taskName, Base.Events.ENotificationType notificationType) {
            lock (_locker)
            {
                DateTime now = DateTime.Now;
                // disable display notifications for normal progress messages
                if ((!SettingsManager.CurrentSettings.ShowProgressNotifications) && notificationType == Base.Events.ENotificationType.TaskOutput)
                {
                    return;
                }

                if (notificationType == Base.Events.ENotificationType.TaskOutput && now.Subtract(_lastAccepted).TotalMilliseconds < 300)
                {
                    return;
                }
                _lastAccepted = now;
                if (_frm?.IsDisposed != false)
                {
                    _frm = new FormNotification
                    {
                        TopMost = SettingsManager.CurrentSettings.KeepNotificationsOnTop,
                        Message = message,
                        Title = taskName,
                        NotificationType = notificationType
                    };
                    const int margin = 5;
                    Rectangle activeArea = new Rectangle(
                            Screen.PrimaryScreen.WorkingArea.X + margin,
                            Screen.PrimaryScreen.WorkingArea.Y + margin,
                            Screen.PrimaryScreen.WorkingArea.Width - (2 * margin),
                            Screen.PrimaryScreen.WorkingArea.Height - (2 * margin));
                    int top = activeArea.Bottom - _frm.Height;
                    int left = activeArea.Right - _frm.Width;
                    _frm.StartPosition = FormStartPosition.Manual;
                    _frm.Location = new Point(left, top);
                    _frm.Show();
                }
                else
                {
                    /// simplistic approach: close and reopen
                    ///_frm.Close();
                    ///_frm = new FormNotification();

                    /// better approach: change of details
                    _frm.StopTimer();
                    _frm.TopMost = SettingsManager.CurrentSettings.KeepNotificationsOnTop;
                    _frm.Message = message;
                    _frm.Title = taskName;
                    _frm.NotificationType = notificationType;
                    _frm.UpdateContent();
                }
            }
        }
    }
}
