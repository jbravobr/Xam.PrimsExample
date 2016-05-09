using System;
using Newtonsoft.Json;
using PropertyChanged;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Schedule : EntityBase
    {
        public DateTime StartSchedule { get; set; }

        public string Message { get; set; }

        [Ignore]
        [JsonIgnore]
        public string StatusAvatar { get; set; }

        [Ignore]
        [JsonIgnore]
        public string StatusDescription { get; set; }
    }
}

