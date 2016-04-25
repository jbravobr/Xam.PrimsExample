using System;

namespace IcatuzinhoApp
{
	public class LogException
	{
		public int Id { get; set; }

		public string ExceptionMessage { get; set; }

		public string InnerExceptionMessage { get; set; }

		public LogExceptionType Type { get; set; }

		public Transaction Trasaction { get; set; }
	}
}

