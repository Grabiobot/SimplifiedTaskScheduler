using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTaskScheduler.Base
{
    public class Accessor
    {
        private static Accessor _intance;
        public static Accessor Instance
        {
            get
            {
                if (_intance == null) _intance = new Accessor();
                return _intance;
            }
        }
        private Accessor()
        {
        }
        public Data.TaskFolder Tasks { get; set; }
    }
}
