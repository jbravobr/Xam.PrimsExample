using PropertyChanged;
using Realms;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Driver : EntityBase
    {
        [Indexed]
        public string Name { get; set; }
    }
}

