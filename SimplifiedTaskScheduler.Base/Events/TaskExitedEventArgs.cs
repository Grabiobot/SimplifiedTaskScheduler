using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Events
{
    public class TaskExitedEventArgs : EventArgs
    {
        public TaskExitedEventArgs() { }
        public TaskExitedEventArgs(int exitCode, string data, string taskId) { ExitCode = exitCode; Data = data; TaskId = taskId; }
        public int ExitCode { get; set; } = 0;
        public string Data { get; set; } = "";
        public string TaskId { get; set; } = "";
    }

}
