﻿using System;

namespace SimplifiedTaskScheduler.Base.Data
{
    public class TaskSchedulingData
    {
        public DateTime StartDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public int DaysBetweenRepetitions { get; set; }
        public EWeekDay WeeksDays { get; set; }
        public EScheduleType ScheduleType { get; set; }
    }
}
