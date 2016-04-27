using System;

namespace IcatuzinhoApp
{
    public class AuthenticationCode : EntityBase
    {
        public string Code { get; set; }

        public User User { get; set; }
    }
}

