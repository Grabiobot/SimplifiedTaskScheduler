
namespace SimplifiedTaskScheduler.Base.Data
{
    public enum ETaskStatus
    {
        Ready = 0,
        Running,
        RunningWithErrors,
        CompletedWithErrors,
        Killed,
        KilledWithErrors
    }
}
