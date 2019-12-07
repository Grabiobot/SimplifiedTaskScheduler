using SimplifiedTaskScheduler.Base;
using SimplifiedTaskScheduler.Base.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimplifiedTaskScheduler.GUI
{
    public sealed class Controller
    {
        #region Singleton
        public static Controller Instance { get; } = new Controller();

        private Controller()
        {
        }
        #endregion

        private ConcurrentDictionary<string, TaskFolder> _foldersById;
        private ConcurrentDictionary<string, TaskData> _tasksById;
        private readonly object _locker = new object();

        public void LoadData(string sourceFile)
        {
            lock (_locker)
            {
                LoadDataFile();
                BuildFoldersList();
                BuildTasksList();
            }
        }

        public void SaveData(string sourceFile)
        {
            lock (_locker)
            {
                SaveDataFile();
            }
        }

        private string GetFilePath() {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            var companyName = fvi.CompanyName;
            var productNAme = fvi.ProductName;
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
            {
                streamWriter.Write(jsonData);
            }
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

        private void BuildFoldersList() {
            _foldersById = new ConcurrentDictionary<string, TaskFolder>();
            AddFolderToList(Accessor.Instance.Tasks);
        }

        private void AddFolderToList(TaskFolder folder)
        {
            _foldersById.TryAdd(folder.Id, folder);
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddFolderToList(folder.SubFolders[i]);
            }
        }

        private void BuildTasksList()
        {
            _tasksById = new ConcurrentDictionary<string, TaskData>();
            AddTasksToList(Accessor.Instance.Tasks);
        }

        private void AddTasksToList(TaskFolder folder)
        {
            for (int i = 0; i < folder.Tasks.Count; i++)
            {
                SetTastRunner(folder.Tasks[i]);
                _tasksById.TryAdd(folder.Tasks[i].Id, folder.Tasks[i]);
            }
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddTasksToList(folder.SubFolders[i]);
            }
        }

        private void SetTastRunner(TaskData taskData)
        {
            taskData.DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(taskData);
            taskData.DebugData.Runner.TaskNotification += Runner_TaskNotification;
        }

        private void Runner_TaskNotification(object sender, Base.Events.TaskNotificationEventArgs e)
        {
            NotificationManager.Instance.ShowNotification(e.Message, e.TaskId, e.TaskName, e.NotificationType);
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
            _tasksById.TryRemove(taskId,out _);
        }

        public void DeleteFolder(string folderId, string parentFolderId)
        {
            TaskFolder folder = GetFolderById(folderId);
            TaskFolder parentFolder = GetFolderById(parentFolderId);
            _foldersById.TryRemove(folder.Id, out _);
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
            _foldersById.TryAdd(folder.Id, folder);
            parentFolder.SubFolders.Add(folder);
            return folder;
        }

        public static TaskData CreateNewTask()
        {
            TaskData taskData = new TaskData()
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "",
                Description = "",
                NextOccurence = DateTime.Now
            };
            taskData.ActioningData.Command = "";
            taskData.ActioningData.Parameters = "";
            taskData.ActioningData.StartIn = "";
            taskData.ActioningData.RunAsOther = false;
            taskData.ActioningData.Domain = System.Environment.MachineName;
            taskData.ActioningData.UserName = System.Environment.UserName;
            taskData.ActioningData.Password = "";
            DateTime now = DateTime.Now;
            taskData.SchedulingData.StartDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
            taskData.SchedulingData.ExpiryDateTime = new DateTime(now.Year + 100, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0);
            taskData.SchedulingData.ScheduleType = EScheduleType.OnceEveryFewDays;
            taskData.SchedulingData.DaysBetweenRepetitions = 3;
            taskData.SchedulingData.WeeksDays = EWeekDay.Monday | EWeekDay.Wednesday | EWeekDay.Friday;
            taskData.DebugData.Runner = new Runner.TaskRunnerSyncTaskRunnerSync(taskData);
            return taskData;
        }

        public void AddChildTask(string folderId, TaskData taskData)
        {
            GetFolderById(folderId).Tasks.Add(taskData);
            _tasksById.TryAdd(taskData.Id, taskData);
        }
    }
}
