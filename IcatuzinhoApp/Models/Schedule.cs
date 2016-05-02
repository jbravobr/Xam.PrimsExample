using System;
using PropertyChanged;
using SQLiteNetExtensions.Attributes;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Schedule : EntityBase
    {
        public DateTime StartSchedule { get; set; }

        public string Message { get; set; }
    }
}

