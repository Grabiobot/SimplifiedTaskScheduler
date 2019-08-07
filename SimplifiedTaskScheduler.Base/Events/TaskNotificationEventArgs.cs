using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Events
{
    public class TaskNotificationEventArgs : EventArgs
    {
        public TaskNotificationEventArgs() { }
        public TaskNotificationEventArgs(string message, string taskId, string taskName, ENotificationType notificationType) {
            Message = message; TaskId = taskId; NotificationType = notificationType;
            TaskName = taskName;
        }
        public ENotificationType NotificationType { get; set; } = ENotificationType.TaskStart;
        public string Message { get; set; } = "";
        public string TaskName { get; set; } = "";
        public string TaskId { get; set; } = "";
    }

}
