using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Travel : EntityBase
    {
        public Schedule Schedule { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}

