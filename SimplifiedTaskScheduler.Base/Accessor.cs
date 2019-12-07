namespace SimplifiedTaskScheduler.Base
{
    public sealed class Accessor
    {
        public static Accessor Instance { get; } = new Accessor();

        private Accessor()
        {
        }

        public Data.TaskFolder Tasks { get; set; }
    }
}
