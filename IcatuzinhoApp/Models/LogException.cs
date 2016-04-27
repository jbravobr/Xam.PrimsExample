using System;

namespace IcatuzinhoApp
{
    public class LogException : EntityBase
    {
        public string Exception { get; set; }

        public string InnerException { get; set; }

        public LogExceptionType Type { get; set; }

        public Transaction Trasaction { get; set; }
    }
}

