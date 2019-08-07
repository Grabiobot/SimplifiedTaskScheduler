using SimplifiedTaskScheduler.Base;
using SimplifiedTaskScheduler.Base.Data;
using SimplifiedTaskScheduler.Base.Events;
using System;
using System.Diagnostics;
using System.Management;

namespace SimplifiedTaskScheduler.Runner
{
    public class TarkRunner : ITaskRunner
    {
        public event EventHandler<TaskDataReceivedEventArgs> ErrorDataReceived;
        public event EventHandler<TaskDataReceivedEventArgs> OutputDataReceived;
        public event EventHandler<TaskExitedEventArgs> Exited;
        public event EventHandler<TaskStatusChangedEventArgs> StatusChanged;
        public event EventHandler<TaskNotificationEventArgs> TaskNotification;
        private bool _hasErrorMessage = false;
        private bool _hasOutputMessage = false;
        private Process _process = null;
        private TaskData _taskData = null;
        private readonly object _locker = new object();
        private ETaskStatus _taskStatus = ETaskStatus.Ready;
        public TarkRunner (TaskData taskData) {
            _taskData = taskData;
            _taskStatus = _taskData.DebugData.TaskStatus;
        }
        public void Run()
        {
            if (IsRunning()) throw new Exception("Previous instance is still running!");
            RunTaskAsProcess(_taskData);
        }
        private void RunTaskAsProcess(TaskData taskData)
        {
            _hasErrorMessage = false;
            _hasOutputMessage = false;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = taskData.ActioningData.Command,
                    Arguments = taskData.ActioningData.Parameters,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = taskData.ActioningData.StartIn,
                    CreateNoWindow = true
                }
            };
            if (taskData.ActioningData.RunAsOther)
            {
                System.Security.SecureString ssPwd = new System.Security.SecureString();
                process.StartInfo.Domain = taskData.ActioningData.Domain;
                process.StartInfo.UserName = taskData.ActioningData.UserName;
                string password = taskData.ActioningData.Password;
                for (int x = 0; x < password.Length; x++)
                {
                    ssPwd.AppendChar(password[x]);
                }
                password = "";
                process.StartInfo.Password = ssPwd;
            }

            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;
            _taskData.DebugData.TaskStatus = ETaskStatus.Running;
            _taskStatus = _taskData.DebugData.TaskStatus;

            string notificationMessageTemplate = "Starting task \"{0}\"...";
            string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name);
            TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskStart));

            StatusChanged?.Invoke(this, new TaskStatusChangedEventArgs(_taskStatus, _taskData.Id));
            _taskData.DebugData.DateStarted = DateTime.Now;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                notificationMessageTemplate = "Error while running \"{0}\": \r\b\t:{1}";
                notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name, ex.Message);
                TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskCrash));
            }
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            _process = process;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            lock (_locker)
            {
                _taskData.DebugData.DateLastSignal = DateTime.Now;
                Process process = sender as Process;
                int result = process.ExitCode; //this tell if there was an error or not        
                string message = ToExitMessage(result.ToString());
                _taskData.DebugData.Output += message;
                Exited?.Invoke(this, new TaskExitedEventArgs(result, message, _taskData.Id));
                _taskData.DebugData.TaskStatus = _taskData.DebugData.HasErrors()?ETaskStatus.CompletedWithErrors: ETaskStatus.Ready;
                _taskStatus = _taskData.DebugData.TaskStatus;
                StatusChanged?.Invoke(this, new TaskStatusChangedEventArgs(_taskStatus, _taskData.Id));
                _hasErrorMessage = false;
                _hasOutputMessage = false;
                _process = null;
                string notificationMessageTemplate = "Task \"{0}\" exited with exit code {1}.";
                string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name, process.ExitCode);
                TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskExit));

            }
        }
        private void Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            lock (_locker)
            {
                _taskData.DebugData.DateLastSignal = DateTime.Now;
                if (!string.IsNullOrEmpty(e.Data)) _hasErrorMessage = true;
                if (_hasErrorMessage)
                {
                    string message = ToErrorMessage(e.Data);
                    _taskData.DebugData.Output += message;
                    ErrorDataReceived?.Invoke(this, new TaskDataReceivedEventArgs(message, _taskData.Id));
                    _taskData.DebugData.TaskStatus = ETaskStatus.RunningWithErrors;
                    _taskStatus = _taskData.DebugData.TaskStatus;
                    StatusChanged?.Invoke(this, new TaskStatusChangedEventArgs(_taskStatus, _taskData.Id));
                    string notificationMessageTemplate = "Task \"{0}\" sent error message:\r\n\t {1}.";
                    string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name, e.Data);
                    TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskError));
                }
            }
        }
        private void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            lock (_locker)
            {
                _taskData.DebugData.DateLastSignal = DateTime.Now;
                if (!string.IsNullOrEmpty(e.Data)) _hasOutputMessage = true;
                if (_hasOutputMessage)
                {
                    string message = ToOutputMessage(e.Data);
                    _taskData.DebugData.Output += message;
                    OutputDataReceived?.Invoke(this, new TaskDataReceivedEventArgs(message, _taskData.Id));
                    string notificationMessageTemplate = "Task \"{0}\" sent normal progress message:\r\n\t {1}.";
                    string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name, e.Data);
                    TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskOutput));
                }
            }
        }
        protected virtual string ToErrorMessage(string message)
        {
            return Environment.NewLine + "ERROR: " + message;
        }
        protected virtual string ToOutputMessage(string message)
        {
            return Environment.NewLine + message;
        }
        protected virtual string ToExitMessage(string message)
        {
            return Environment.NewLine + "Process exited with ExitCode: " + message;
        }
        public void Kill()
        {
            DoKill();
            string notificationMessageTemplate = "Task \"{0}\" killed.";
            string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name);
            TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskKilled));
        }
        private void DoKill()
        {
            try
            {
                if (_process != null && !_process.HasExited)
                {
                    //_process.Kill();
                    KillProcessAndChildrens(_process.Id);
                    _process.OutputDataReceived -= Process_OutputDataReceived;
                    _process.ErrorDataReceived -= Process_ErrorDataReceived;
                    _process.Exited -= Process_Exited;
                }
            }
            catch (Exception exc)
            {
            }
            _taskData.DebugData.TaskStatus = _taskData.DebugData.HasErrors() ? ETaskStatus.KilledWithErrors : ETaskStatus.Killed;
            _taskStatus = _taskData.DebugData.TaskStatus;
            StatusChanged?.Invoke(this, new TaskStatusChangedEventArgs(_taskStatus, _taskData.Id));
            _hasErrorMessage = false;
            _hasOutputMessage = false;
        }
        private static void KillProcessAndChildrens(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            // We must kill child processes first!
            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillProcessAndChildrens(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
            }

            // Then kill parents.
            try
            {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
        public bool IsRunning()
        {
            try
            {
                return _process != null && !_process.HasExited;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        public ETaskStatus TaskStatus { get { return _taskStatus; } }
        public void CloseIdle()
        {
            if (!IsRunning()) return;
            TimeSpan idleTime = new TimeSpan(_taskData.ActioningData.StopIfIdleHours,
                _taskData.ActioningData.StopIfIdleMinutes, _taskData.ActioningData.StopIfIdleSeconds);
            if (idleTime.TotalSeconds == 0) return; // Do not killl tasks with 0 idle hours, minutes, seconds.
            if (_taskData.DebugData.DateLastSignal.Add(idleTime) < DateTime.Now)
            {
                DoKill();
                _taskData.DebugData.TaskStatus = ETaskStatus.Ready;
                StatusChanged?.Invoke(this, new TaskStatusChangedEventArgs(_taskStatus, _taskData.Id));
                string notificationMessageTemplate = "Task \"{0}\" stopped after being idle";
                string notificationMessage = string.Format(notificationMessageTemplate, _taskData.Name);
                TaskNotification?.Invoke(this, new TaskNotificationEventArgs(notificationMessage, _taskData.Id, _taskData.Name, ENotificationType.TaskIdleKilled));
            }
        }
    }
}