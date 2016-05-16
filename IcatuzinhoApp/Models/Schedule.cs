using System;
using Newtonsoft.Json;
using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Schedule : EntityBase
    {
        public DateTime StartSchedule { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public string StatusAvatar { get; set; }

        [JsonIgnore]
        public string StatusDescription { get; set; }
    }
}

