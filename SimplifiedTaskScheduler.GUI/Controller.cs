using SimplifiedTaskScheduler.Base;
using SimplifiedTaskScheduler.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedTaskScheduler.GUI
{
    public class Controller
    {
        #region Singleton
        private static Controller _intance;
        public static Controller Instance
        {
            get
            {
                if (_intance == null) _intance = new Controller();
                return _intance;
            }
        }
        private Controller()
        {
        }
        #endregion

        private Dictionary<string, TaskFolder> _foldersById;
        private Dictionary<string, TaskData> _tasksById;
        public void LoadData(string sourceFile)
        {
            //AddFakeData();
            LoadDataFile();
            BuildFoldersList();
            BuildTasksList();
        }
        public void SaveData(string sourceFile)
        {
            //AddFakeData();
            SaveDataFile();
        }
        private string GetFilePath() {

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            var companyName = fvi.CompanyName;
            var productNAme = fvi.ProductName;
            var productVersion = fvi.ProductVersion;
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = System.IO.Path.Combine(appDataFolder, companyName, productNAme);
            System.IO.Directory.CreateDirectory(folderPath);
            string filePath = System.IO.Path.Combine(folderPath, "tasks.json");
            return filePath;
        }
        private void SaveDataFile()
        {

            string filePath = GetFilePath();
            string jsonData = JsonHelper.SerializeObject(Accessor.Instance.Tasks, true);
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filePath, false))
                streamWriter.Write(jsonData);
        }
        private void LoadDataFile()
        {
            string filePath = GetFilePath();
            string jsonData = "{}";
            if (System.IO.File.Exists(filePath))
            {
                using (var reader = new System.IO.StreamReader(filePath))
                {
                    jsonData = reader.ReadToEnd();
                }
            }
            Accessor.Instance.Tasks = JsonHelper.DeserializeObject<TaskFolder>(jsonData);
            if (Accessor.Instance.Tasks == null || string.IsNullOrEmpty(Accessor.Instance.Tasks.Id))
            {
                Accessor.Instance.Tasks = new TaskFolder()
                {
                    Id = Guid.NewGuid().ToString("N")
                    ,
                    Name = "Simple Tasks Scheduler"
                    ,
                    Tasks = new List<TaskData>()
                    ,
                    SubFolders = new List<TaskFolder>()
                };
            }
        }
        private void AddFakeData()
        {
            if (Accessor.Instance.Tasks == null)
            {
                Accessor.Instance.Tasks = new TaskFolder()
                {
                    Id = Guid.NewGuid().ToString("N")
                    ,
                    Name = "Simple Tasks Scheduler"
                    ,
                    Tasks = new List<TaskData>()
                    ,
                    SubFolders = new List<TaskFolder>()
                };
            }

            // Add folder: "Backup"
            Accessor.Instance.Tasks.SubFolders.Add(new TaskFolder()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Backup",
                Tasks = new List<TaskData>(),
                SubFolders = new List<TaskFolder>()
            });

            // Add task: "Backup my work to a reasonably safe location"
            Accessor.Instance.Tasks.SubFolders[0].Tasks.Add(new TaskData()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Backup my work to a reasonably safe location",
                Description = "Copy from working dir to backup location"
            });
            Accessor.Instance.Tasks.SubFolders[0].Tasks[0].ActioningData.Command = "powershell.exe";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[0].ActioningData.Parameters = "-NoExit -ExecutionPolicy Bypass \"G:\\my_work\\powershell\\Simple` Task` Scheduler\\backup__my_work.ps1\"";
            //Accessor.Instance.Tasks.SubFolders[0].Tasks[0].ActioningData.Command = "notepad.exe";
            //Accessor.Instance.Tasks.SubFolders[0].Tasks[0].ActioningData.Parameters = "\"E:\\System Resources\\Task Scheduler\\backup__my_work.ps1\"";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[0].ActioningData.RunAsOther = false;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[0].DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(Accessor.Instance.Tasks.SubFolders[0].Tasks[0]);


            // Add task: "Backup my pictures"
            Accessor.Instance.Tasks.SubFolders[0].Tasks.Add(new TaskData()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Backup my pictures",
                Description = "Copy Pictures to my backup location",
                NextOccurence = DateTime.Now
            });
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Command = "notepad.exe";
            //Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Parameters = "\"E:\\System Resources\\Task Scheduler\\backup__my_work.ps1\"";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Parameters = "\"G:\\my_work\\powershell\\Simple Task Scheduler\\backup__my_work.ps1\"";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.StartIn = "C:\\Users\\grabio\\Documents\\";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.RunAsOther = false;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Domain = System.Environment.MachineName;// "DESKTOP-RUFC7H4";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.UserName = System.Environment.UserName;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Password = "mypassword";
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.StartDateTime = new DateTime(2019, 02, 17, 20, 45, 00);
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.ExpiryDateTime = new DateTime(2020, 12, 31, 23, 59, 59);
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.ScheduleType = EScheduleType.OnceEveryFewDays;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.DaysBetweenRepetitions = 1;
            //Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.WeeksBetweenRepetitions = 1;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].SchedulingData.WeeksDays = EWeekDay.Monday | EWeekDay.Tuesday;
            Accessor.Instance.Tasks.SubFolders[0].Tasks[1].DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(Accessor.Instance.Tasks.SubFolders[0].Tasks[1]);

            // Add folder: "Checks"
            Accessor.Instance.Tasks.SubFolders.Add(new TaskFolder()
            {
                Id = Guid.NewGuid().ToString("N")
                ,
                Name = "Checks"
                ,
                Tasks = new List<TaskData>()
                ,
                SubFolders = new List<TaskFolder>()
            });
        }
        private void BuildFoldersList() {
            _foldersById = new Dictionary<string, TaskFolder>();
            AddFolderToList(Accessor.Instance.Tasks);
        }
        private void AddFolderToList(TaskFolder folder)
        {
            _foldersById.Add(folder.Id, folder);
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddFolderToList(folder.SubFolders[i]);
            }
        }
        private void BuildTasksList()
        {
            _tasksById = new Dictionary<string, TaskData>();
            AddTasksToList(Accessor.Instance.Tasks);
        }
        private void AddTasksToList(TaskFolder folder)
        {
            for (int i = 0; i < folder.Tasks.Count; i++)
            {
                SetTastRunner(folder.Tasks[i]);
                _tasksById.Add(folder.Tasks[i].Id, folder.Tasks[i]);
            }
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddTasksToList(folder.SubFolders[i]);
            }
        }
        private void SetTastRunner(TaskData taskData)
        {
            taskData.DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(taskData);
        }
        public TaskFolder GetFolderById(string id)
        {
            return _foldersById[id];
        }
        public TaskData GetTaskBeId(string id)
        {
            return _tasksById[id];
        }
        public void DeleteTask(string taskId, string folderId)
        {
            TaskFolder folder = GetFolderById(folderId);
            TaskData task = GetTaskBeId(taskId);
            folder.Tasks.Remove(task);
            _tasksById.Remove(taskId);
        }
        public void DeleteFolder(string folderId, string parentFolderId)
        {
            TaskFolder folder = GetFolderById(folderId);
            TaskFolder parentFolder = GetFolderById(parentFolderId);
            _foldersById.Remove(folder.Id);
            parentFolder.SubFolders.Remove(folder);
        }
        public TaskFolder AddChildFolder(string parentFolderId)
        {
            TaskFolder parentFolder = GetFolderById(parentFolderId);
            TaskFolder folder = new TaskFolder() {
                Id = Guid.NewGuid().ToString("N"),
                Name = "",
                Tasks = new List<TaskData>(),
                SubFolders = new List<TaskFolder>()
            };
            _foldersById.Add(folder.Id, folder);
            parentFolder.SubFolders.Add(folder);
            return folder;
        }
        public TaskData CreateNewTask() {
            TaskData taskData = new TaskData()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "",
                Description = "",
                NextOccurence = DateTime.Now
            };
            taskData.ActioningData.Command = "";
            //Accessor.Instance.Tasks.SubFolders[0].Tasks[1].ActioningData.Parameters = "\"E:\\System Resources\\Task Scheduler\\backup__my_work.ps1\"";
            taskData.ActioningData.Parameters = "";
            taskData.ActioningData.StartIn = "";
            taskData.ActioningData.RunAsOther = false;
            taskData.ActioningData.Domain = System.Environment.MachineName;// "DESKTOP-RUFC7H4";
            taskData.ActioningData.UserName = System.Environment.UserName;
            taskData.ActioningData.Password = "";
            DateTime now = DateTime.Now;
            taskData.SchedulingData.StartDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
            DateTime now100 = now.AddYears(100);
            taskData.SchedulingData.ExpiryDateTime = new DateTime(now.Year + 100, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
            taskData.SchedulingData.ScheduleType = EScheduleType.OnceEveryFewDays;
            taskData.SchedulingData.DaysBetweenRepetitions = 3;
            //taskData.SchedulingData.WeeksBetweenRepetitions = 1;
            taskData.SchedulingData.WeeksDays = EWeekDay.Monday | EWeekDay.Wednesday | EWeekDay.Friday;
            taskData.DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(taskData);
            return taskData;
        }
        public void AddChildTask(string folderId, TaskData taskData)
        {
            GetFolderById(folderId).Tasks.Add(taskData);
            _tasksById.Add(taskData.Id, taskData);
        }
    }
}
