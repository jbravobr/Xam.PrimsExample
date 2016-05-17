using System;
using PropertyChanged;
namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class TravelDTO
    {
        public int Id { get; set; }

        public Schedule Schedule { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}

