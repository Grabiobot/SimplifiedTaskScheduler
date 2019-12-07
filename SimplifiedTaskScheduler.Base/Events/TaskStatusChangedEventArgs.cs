using System;

namespace SimplifiedTaskScheduler.Base.Events
{
    public class TaskStatusChangedEventArgs:EventArgs
    {
        public TaskStatusChangedEventArgs() { }
        public TaskStatusChangedEventArgs(Data.ETaskStatus taskStatus, string taskId) { TaskStatus = taskStatus; TaskId = taskId; }
        public Data.ETaskStatus TaskStatus { get; set; } = Data.ETaskStatus.Ready;
        public string TaskId { get; set; } = "";
    }
}
