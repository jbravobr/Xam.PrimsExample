using System;
using System.Collections.Generic;
using PropertyChanged;
using SQLiteNetExtensions.Attributes;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Travel : EntityBase
    {
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public List<Schedule> Schedule { get; set; }

        [OneToOne]
        public Driver Driver { get; set; }

        public int DriverId { get; set; }

        [OneToOne]
        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }
    }
}

