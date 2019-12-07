using System;

namespace SimplifiedTaskScheduler.Base.Events
{
    public class TaskDataReceivedEventArgs : EventArgs
    {
        public TaskDataReceivedEventArgs() { }
        public TaskDataReceivedEventArgs(string data, string taskId) { Data = data; TaskId = taskId; }
        public string Data { get; set; } = "";
        public string TaskId { get; set; } = "";
    }
}
