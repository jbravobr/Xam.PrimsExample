using System;

namespace IcatuzinhoApp
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime DtRegister { get; set; }

        public DateTime? DtLasUpdate { get; set; }

        public bool Status { get; set; }
    }
}

