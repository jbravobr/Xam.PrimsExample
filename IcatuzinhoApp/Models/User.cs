﻿using System;
using System.ComponentModel;
using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}

