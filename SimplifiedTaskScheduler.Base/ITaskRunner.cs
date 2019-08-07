using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base
{
    public interface ITaskRunner
    {
        event EventHandler<Events.TaskDataReceivedEventArgs> ErrorDataReceived;
        event EventHandler<Events.TaskExitedEventArgs> Exited;
        event EventHandler<Events.TaskDataReceivedEventArgs> OutputDataReceived;
        event EventHandler<Events.TaskStatusChangedEventArgs> StatusChanged;
        event EventHandler<Events.TaskNotificationEventArgs> TaskNotification;
        bool IsRunning();
        void Kill();
        void Run();
        Data.ETaskStatus TaskStatus { get; }
        void CloseIdle();
    }
}
