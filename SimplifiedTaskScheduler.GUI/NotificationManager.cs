using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public class NotificationManager
    {
        private static NotificationManager _intance=new NotificationManager();
        public static NotificationManager Instance
        {
            get
            {
                return _intance;
            }
        }
        private NotificationManager()
        {
        }
        FormNotification _frm = null;// new FormNotification();
        private readonly object _locker = new object();
        private DateTime _lastAccepted = DateTime.Now;
        public void ShowNotification(string message, string taskId, string taskName, Base.Events.ENotificationType notificationType) {
            lock (_locker)
            {
                if (!SettingsManager.CurrentSettings.ShowProgressNotifications)
                {
                    // disable display notifications for normal progress messages
                    if (notificationType == Base.Events.ENotificationType.TaskOutput) return;
                }

                DateTime now = DateTime.Now;
                //if (notificationType == Base.Events.ENotificationType.TaskOutput)
                //{
                //    if (now.Subtract(_lastAccepted).TotalMilliseconds < 300) return;
                //}
                _lastAccepted = now;
                if (_frm == null || _frm.IsDisposed)
                {
                    _frm = new FormNotification();

                    _frm.Message = message;
                    _frm.Title = taskName;
                    _frm.NotificationType = notificationType;
                    const int margin = 5;
                    Rectangle activeArea = new Rectangle(
                            Screen.PrimaryScreen.WorkingArea.X + margin,
                            Screen.PrimaryScreen.WorkingArea.Y + margin,
                            Screen.PrimaryScreen.WorkingArea.Width - 2 * margin,
                            Screen.PrimaryScreen.WorkingArea.Height - 2 * margin);
                    int top = activeArea.Bottom - _frm.Height;
                    int left = activeArea.Right - _frm.Width;
                    _frm.StartPosition = FormStartPosition.Manual;
                    _frm.Location = new Point(left, top);
                    _frm.Show();
                    return;
                }
                else
                {
                    // simplistic apprach: close and reopen
                    //_frm.Close();
                    //_frm = new FormNotification();
                    // better approach: change for details
                    _frm.StopTimer();
                    _frm.Message = message;
                    _frm.Title = taskName;
                    _frm.NotificationType = notificationType;
                    _frm.UpdateContent();
                    return;
                }
                //_frm.Message = message;
                //_frm.Title = taskName;
                //_frm.NotificationType = notificationType;
                //const int margin = 5;
                //Rectangle activeArea = new Rectangle(
                //        Screen.PrimaryScreen.WorkingArea.X + margin,
                //        Screen.PrimaryScreen.WorkingArea.Y + margin,
                //        Screen.PrimaryScreen.WorkingArea.Width - 2 * margin,
                //        Screen.PrimaryScreen.WorkingArea.Height - 2 * margin);
                //int top = activeArea.Bottom - _frm.Height;
                //int left = activeArea.Right - _frm.Width;
                //_frm.StartPosition = FormStartPosition.Manual;
                //_frm.Location = new Point(left, top);
                //_frm.Show();
            }
        }
    }
}
