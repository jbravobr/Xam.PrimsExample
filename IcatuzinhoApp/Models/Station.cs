﻿using System;

namespace IcatuzinhoApp
{
    public class Station : EntityBase
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}

