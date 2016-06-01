﻿using PropertyChanged;
using Realms;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class AuthenticationCode : RealmObject
    {
        [ObjectId]
        public int Id { get; set; }

        public string Code { get; set; }

        public User User { get; set; }
    }
}

