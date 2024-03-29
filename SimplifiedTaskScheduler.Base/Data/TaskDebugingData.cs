﻿using Newtonsoft.Json;
using System;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskDebugingData
    {
        [JsonIgnore]
        public ETaskStatus TaskStatus  { get; set; } = ETaskStatus.Ready;

        public string Output { get; set; } = "";
        public string ExitCode { get; set; } = "";

        public DateTime? DateStarted { get; set; } = null;

        [JsonIgnore]
        public DateTime DateLastSignal { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ITaskRunner Runner { get; set; } = null;

        public bool HasErrors() {
            return TaskStatus == ETaskStatus.RunningWithErrors || TaskStatus == ETaskStatus.CompletedWithErrors;
        }
    }
}
