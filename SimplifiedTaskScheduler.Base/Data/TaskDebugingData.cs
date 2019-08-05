using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskDebugingData
    {
        public ETaskStatus TaskStatus  { get; set; } = ETaskStatus.Ready;
        public string Output { get; set; } = "";
        public string ExitCode { get; set; } = "";

        public DateTime DateStarted { get; set; } = DateTime.Now;
        public DateTime DateLastSignal { get; set; } = DateTime.Now;
        [JsonIgnore]
        public ITaskRunner Runner { get; set; } = null;
        public bool HasErrors() {
            return TaskStatus == ETaskStatus.RunningWithErrors || TaskStatus == ETaskStatus.CompletedWithErrors;
        }
    }
}
