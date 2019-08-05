using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskFolder
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<TaskFolder> SubFolders { get; set; } = new List<TaskFolder>();
        public List<TaskData> Tasks { get; set; } = new List<TaskData>();
    }
}
