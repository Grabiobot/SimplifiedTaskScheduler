using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskActioningData
    {
        public string Command { get; set; } = "";
        public string Parameters { get; set; } = "";
        public string StartIn { get; set; }
        public bool RunAsOther { get; set; } = false;
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int StopIfIdleHours { get; set; } = 0;
        public int StopIfIdleMinutes { get; set; } = 5;
        public int StopIfIdleSeconds { get; set; } = 0;
    }
}
