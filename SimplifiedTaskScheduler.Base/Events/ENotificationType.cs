using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base.Events
{
    public enum ENotificationType
    {
        TaskStart, TaskError, TaskKilled, TaskIdleKilled, TaskOutput, TaskExit, TaskCrash
    }
}
