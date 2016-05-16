using PropertyChanged;
using Realms;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Transaction : EntityBase
    {
        [Indexed]
        public string Name { get; set; }

        public string DetailKey { get; set; }

        public string DetailName { get; set; }
    }
}

