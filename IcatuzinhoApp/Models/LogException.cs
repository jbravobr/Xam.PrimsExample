using System;

namespace IcatuzinhoApp
{
    public class LogException : EntityBase
    {
        public DateTimeOffset DtCreation { get; set; }

        public string Exception { get; set; }

        public string InnerException { get; set; }

        public Transaction Trasaction { get; set; }
    }
}

