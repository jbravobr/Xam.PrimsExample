using System;
using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Driver : EntityBase
    {
        public string Name { get; set; }
    }
}

