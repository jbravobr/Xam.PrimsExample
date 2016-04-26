using System;

namespace IcatuzinhoApp
{
	public class LogBook : BaseEntity
	{
		public Travel Travel { get; set; }

		public User Userr { get; set; }

		public bool Status { get; set; }
	}
}

