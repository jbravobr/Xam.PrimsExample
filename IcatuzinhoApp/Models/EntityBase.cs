using System;
using SQLite.Net.Attributes;

namespace IcatuzinhoApp
{

    public class EntityBase
    {
        [PrimaryKey]
        public int Id { get; set; }

        public DateTime DtRegister { get; set; }

        public DateTime? DtLasUpdate { get; set; }

        public bool Status { get; set; }
    }
}

