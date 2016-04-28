using System;
using PropertyChanged;
using SQLite.Net.Attributes;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string TransactionDetails { get; set; }
    }
}

