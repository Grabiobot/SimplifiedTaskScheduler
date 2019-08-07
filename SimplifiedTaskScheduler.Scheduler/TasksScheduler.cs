using SimplifiedTaskScheduler.Base.Data;
using System;
using System.Collections.Generic;

namespace SimplifiedTaskScheduler.Scheduler
{
    public class TasksScheduler
    {
        #region Singleton
        private static TasksScheduler _intance;
        public static TasksScheduler Instance
        {
            get
            {
                if (_intance == null) _intance = new TasksScheduler();
                return _intance;
            }
        }
        private TasksScheduler()
        {
        }
        #endregion
        List<TaskData> _tasks = new List<TaskData>();
        public void ReBuildQueue(TaskFolder taskFolder)
        {
            List<TaskData>  tasks = AddTasksToList(taskFolder);
            //tasks.Sort((x, y) => x.NextOccurence.CompareTo(y.NextOccurence));
            tasks.Sort((x, y) =>
            {
                if (!x.NextOccurence.HasValue)
                {
                    if (!y.NextOccurence.HasValue) return 0; // equal
                    else return -1; // y is greater
                }
                else
                {
                    if (!y.NextOccurence.HasValue) return 1; // x is greater
                    //if (x == y) return 0; // equal
                    //if (x < y) return -1; // y is greater
                    //else return 1;
                    return ((DateTime)x.NextOccurence).CompareTo(y.NextOccurence);
                }
            });
            _tasks = tasks;
        }
        private List<TaskData> AddTasksToList(TaskFolder folder)
        {
            List<TaskData> tasks = new List<TaskData>();
            AddTasksToList(folder, tasks);
            return tasks;
        }
        private void AddTasksToList(TaskFolder folder, List<TaskData> list)
        {
            TaskData taskData;
            for (int i = 0; i < folder.Tasks.Count; i++)
            {
                taskData = folder.Tasks[i];
                if (ValidateTask(taskData))
                    list.Add(taskData);
            }
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddTasksToList(folder.SubFolders[i], list);
            }
        }
        private bool ValidateTask(TaskData taskData) {
            if (!taskData.IsEnabled) return false;
            if (taskData.SchedulingData.StartDateTime > DateTime.Now) return false;
            if (taskData.SchedulingData.ExpiryDateTime < DateTime.Now) return false;
            taskData.NextOccurence = CalculateNextOccurence(taskData);
            if (taskData.NextOccurence == null) return false;
            return true;
        }
        public void RunNext() {
            var now = DateTime.Now;
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].NextOccurence == null) continue;
                if (_tasks[i].NextOccurence > now) break;
                if (_tasks[i].DebugData.Runner.IsRunning()) continue;
                _tasks[i].LastRun = DateTime.Now;
                _tasks[i].NextOccurence = CalculateNextOccurence(_tasks[i]);
                _tasks[i].DebugData.Runner.Run();
            }
        }
        public void Cleanup(TaskFolder taskFolder)
        {
            List<TaskData> tasks = AddTasksToCleanupList(taskFolder);
            //TimeSpan timeSpan = new TimeSpan(0, 0, 5);
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].DebugData.Runner.CloseIdle();
            }
        }
        private List<TaskData> AddTasksToCleanupList(TaskFolder folder)
        {
            List<TaskData> tasks = new List<TaskData>();
            AddTasksToCleanupList(folder, tasks);
            return tasks;
        }
        private void AddTasksToCleanupList(TaskFolder folder, List<TaskData> list)
        {
            TaskData taskData;
            for (int i = 0; i < folder.Tasks.Count; i++)
            {
                taskData = folder.Tasks[i];
                list.Add(taskData);
            }
            for (int i = 0; i < folder.SubFolders.Count; i++)
            {
                AddTasksToList(folder.SubFolders[i], list);
            }
        }

        private DateTime? CalculateNextOccurence(TaskData taskData)
        {
            DateTime? result = CalculateNextOccurence_ByType(taskData);
            if (result==null || result > taskData.SchedulingData.ExpiryDateTime) return null;
            return result;
        }
        private DateTime? CalculateNextOccurence_ByType(TaskData taskData)
        {
            switch (taskData.SchedulingData.ScheduleType)
            {
                case EScheduleType.RunOnce:
                    return CalculateNextOccurence_RunOnce(taskData);
                case EScheduleType.OnceEveryFewDays:
                    return CalculateNextOccurence_OnceEveryFewDays(taskData);
                case EScheduleType.WeeklyBase:
                    return CalculateNextOccurence_WeeklyBase(taskData);
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        private DateTime? CalculateNextOccurence_RunOnce(TaskData taskData)
        {
            if (taskData.LastRun != null) return null;
            return taskData.SchedulingData.StartDateTime;
        }
        private DateTime? CalculateNextOccurence_OnceEveryFewDays(TaskData taskData)
        {
            if (taskData.LastRun == null) return taskData.SchedulingData.StartDateTime;
            else return taskData.LastRun?.AddDays(taskData.SchedulingData.DaysBetweenRepetitions);
        }
        private DateTime? CalculateNextOccurence_WeeklyBase(TaskData taskData)
        {
            DateTime now = DateTime.Now;
            DateTime runPlus_0 = new DateTime(now.Year, now.Month, now.Day, taskData.SchedulingData.StartDateTime.Hour, taskData.SchedulingData.StartDateTime.Minute, taskData.SchedulingData.StartDateTime.Second, 0);
            DateTime runPlus_1 = runPlus_0.AddDays(1);
            DateTime runPlus_2 = runPlus_0.AddDays(2);
            DateTime runPlus_3 = runPlus_0.AddDays(3);
            DateTime runPlus_4 = runPlus_0.AddDays(4);
            DateTime runPlus_5 = runPlus_0.AddDays(5);
            DateTime runPlus_6 = runPlus_0.AddDays(6);
            DateTime[] possibleOptions = new DateTime[] { runPlus_0, runPlus_1, runPlus_2, runPlus_3, runPlus_4, runPlus_5, runPlus_6 };
            List<DateTime> validOptions = new List<DateTime>();
            foreach (var option in possibleOptions)
            {
                if (IsSameWeekDay(option.DayOfWeek, taskData.SchedulingData.WeeksDays)){
                    if (option <= taskData.LastRun) continue;
                    //if (option < now && (taskData.LastRun != option))
                    //{
                    //    validOptions.Add(now);
                    //}
                    //else {
                    //}
                    validOptions.Add(option);
                }
            }
            if (validOptions.Count == 0) return null;
            return validOptions[0];
        }
        private bool IsSameWeekDay(DayOfWeek dayOfWeek, Base.Data.EWeekDay weekDay)
        {
            Base.Data.EWeekDay targetWeekDay;
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    targetWeekDay = EWeekDay.Friday;
                    break;
                case DayOfWeek.Monday:
                    targetWeekDay = EWeekDay.Monday;
                    break;
                case DayOfWeek.Saturday:
                    targetWeekDay = EWeekDay.Saturday;
                    break;
                case DayOfWeek.Sunday:
                    targetWeekDay = EWeekDay.Sunday;
                    break;
                case DayOfWeek.Thursday:
                    targetWeekDay = EWeekDay.Thursday;
                    break;
                case DayOfWeek.Tuesday:
                    targetWeekDay = EWeekDay.Tuesday;
                    break;
                case DayOfWeek.Wednesday:
                    targetWeekDay = EWeekDay.Wednesday;
                    break;
                default:
                    throw new NotImplementedException(); 
            }
            bool result = (weekDay & targetWeekDay) == targetWeekDay;
            return result;
        }
    }
}
