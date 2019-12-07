///using Newtonsoft.Json;
using System;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskData
    {
        public string Id { get; set; } = "";
        public bool IsEnabled { get; set; } = true;
        public bool NotifyProgressOutput { get; set; } = true;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? NextOccurence { get; set; } = DateTime.Now;
        public DateTime? LastRun { get; set; } = null;
        public TaskSchedulingData SchedulingData { get; set; } = new TaskSchedulingData();
        public TaskActioningData ActioningData { get; set; } = new TaskActioningData();
        //[JsonIgnore]
        public TaskDebugingData DebugData { get; set; } = new TaskDebugingData();
    }
}
