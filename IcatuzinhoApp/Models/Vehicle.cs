﻿using System;
using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Vehicle : EntityBase
    {
        public int Number { get; set; }

        public int SeatsTotal { get; set; }

        public int SeatsAvailable { get; set; }
    }
}

