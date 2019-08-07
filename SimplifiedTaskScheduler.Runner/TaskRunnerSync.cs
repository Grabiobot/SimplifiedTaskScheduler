using SimplifiedTaskScheduler.Base;
using SimplifiedTaskScheduler.Base.Data;
using SimplifiedTaskScheduler.Base.Events;
using System;
using System.Diagnostics;
using System.Management;
using System.Threading;

namespace SimplifiedTaskScheduler.Runner
{
    /// <summary>
    /// This class is a wrapper to the internal TarkRunner. TaskRunner does all the task-running logic.
    /// This one synchronizes calls in the main thread.
    /// </summary>
    public class TaskRunnerSyncTaskRunnerSync : ITaskRunner, System.ComponentModel.ISynchronizeInvoke
    {
        private TarkRunner  _runner = null;

        #region ITaskRunner

        public ETaskStatus TaskStatus => _runner.TaskStatus;
        public event EventHandler<TaskDataReceivedEventArgs> ErrorDataReceived;
        public event EventHandler<TaskExitedEventArgs> Exited;
        public event EventHandler<TaskDataReceivedEventArgs> OutputDataReceived;
        public event EventHandler<TaskStatusChangedEventArgs> StatusChanged;
        public event EventHandler<TaskNotificationEventArgs> TaskNotification;
        public bool IsRunning()
        {
            return _runner.IsRunning();
        }
        public void Kill()
        {
            _runner.Kill();
        }
        public void Run()
        {
            _runner.Run();
        }
        public void CloseIdle()
        {
            _runner.CloseIdle();
        }
        #endregion

        #region ISynchronizeInvoke
        private readonly SynchronizationContext _currentContext = SynchronizationContext.Current;
        private readonly Thread _mainThread = Thread.CurrentThread;
        private readonly object _invokeLocker = new object();
        public bool InvokeRequired
        {
            get
            {
                return System.Threading.Thread.CurrentThread.ManagedThreadId != this._mainThread.ManagedThreadId;
            }
        }
        public object Invoke(Delegate method, object[] args)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            lock (_invokeLocker)
            {
                object objectToGet = null;

                SendOrPostCallback invoker = new SendOrPostCallback(
                delegate (object data)
                {
                    objectToGet = method.DynamicInvoke(args);
                });

                _currentContext.Send(new SendOrPostCallback(invoker), method.Target);

                return objectToGet;
            }
        }
        public object Invoke(Delegate method)
        {
            return Invoke(method, null);
        }
        [Obsolete("Not implemented!", true)]
        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            throw new NotSupportedException("Not implemented!");
        }
        [Obsolete("Not implemented!", true)]
        public object EndInvoke(IAsyncResult result)
        {
            throw new NotSupportedException("Not implemented!");
        }
        #endregion

        #region Thread synchronization
        private delegate void FireStatusChangedCallback(object sender, TaskStatusChangedEventArgs e);
        private delegate void FireOutputDataReceivedCallback(object sender, TaskDataReceivedEventArgs e);
        private delegate void FireErrorDataReceivedCallback(object sender, TaskDataReceivedEventArgs e);
        private delegate void FireExitedCallback(object sender, TaskExitedEventArgs e);
        private delegate void FireTaskNotificationCallback(object sender, TaskNotificationEventArgs e);
        public TaskRunnerSyncTaskRunnerSync(TaskData taskData)
        {
            _runner = new TarkRunner (taskData);
            _runner.ErrorDataReceived += _runner_ErrorDataReceived;
            _runner.Exited += _runner_Exited;
            _runner.OutputDataReceived += _runner_OutputDataReceived;
            _runner.StatusChanged += _runner_StatusChanged;
            _runner.TaskNotification += _runner_TaskNotification;
        }

        private void _runner_TaskNotification(object sender, TaskNotificationEventArgs e)
        {
            FireTaskNotification(sender, e);
        }

        private void _runner_StatusChanged(object sender, TaskStatusChangedEventArgs e)
        {
            FireStatusChanged(sender, e);
        }
        private void _runner_OutputDataReceived(object sender, TaskDataReceivedEventArgs e)
        {
            FireOutputDataReceived(sender, e);
        }
        private void _runner_Exited(object sender, TaskExitedEventArgs e)
        {
            FireExited(sender, e);
        }
        private void _runner_ErrorDataReceived(object sender, TaskDataReceivedEventArgs e)
        {
            FireErrorDataReceived(sender, e);
        }
        private void FireStatusChanged(object sender, TaskStatusChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                FireStatusChangedCallback d = new FireStatusChangedCallback(FireStatusChanged);
                this?.Invoke(d, new object[] { sender, e });
            }
            else
            {
                StatusChanged?.Invoke(sender, e);
            }
        }
        private void FireOutputDataReceived(object sender, TaskDataReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                FireOutputDataReceivedCallback d = new FireOutputDataReceivedCallback(FireOutputDataReceived);
                this?.Invoke(d, new object[] { sender, e });
            }
            else
            {
                OutputDataReceived?.Invoke(sender, e);
            }
        }
        private void FireErrorDataReceived(object sender, TaskDataReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                FireErrorDataReceivedCallback d = new FireErrorDataReceivedCallback(FireErrorDataReceived);
                this?.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ErrorDataReceived?.Invoke(sender, e);
            }
        }
        private void FireExited(object sender, TaskExitedEventArgs e)
        {
            if (InvokeRequired)
            {
                FireExitedCallback d = new FireExitedCallback(FireExited);
                this?.Invoke(d, new object[] { sender, e });
            }
            else
            {
                Exited?.Invoke(sender, e);
            }
        }
        private void FireTaskNotification(object sender, TaskNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                FireTaskNotificationCallback d = new FireTaskNotificationCallback(FireTaskNotification);
                this?.Invoke(d, new object[] { sender, e });
            }
            else
            {
                TaskNotification?.Invoke(sender, e);
            }
        }
        #endregion

    }
}
