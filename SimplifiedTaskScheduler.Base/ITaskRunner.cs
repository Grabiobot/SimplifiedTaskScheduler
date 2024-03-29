﻿using System;

namespace SimplifiedTaskScheduler.Base
{
    public interface ITaskRunner
    {
        event EventHandler<Events.TaskDataReceivedEventArgs> ErrorDataReceived;
        event EventHandler<Events.TaskExitedEventArgs> Exited;
        event EventHandler<Events.TaskDataReceivedEventArgs> OutputDataReceived;
        event EventHandler<Events.TaskStatusChangedEventArgs> StatusChanged;
        event EventHandler<Events.TaskNotificationEventArgs> TaskNotification;
        event EventHandler<Events.TaskDataReceivedEventArgs> ManagementDataReceived;
        bool IsRunning();
        void Kill();
        void Run();
        Data.ETaskStatus TaskStatus { get; }
        void CloseIdle();
    }
}
