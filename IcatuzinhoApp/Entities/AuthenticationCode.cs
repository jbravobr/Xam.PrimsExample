using System;

namespace IcatuzinhoApp
{
	public class AuthenticationCode : BaseEntity
	{
		public long Code { get; set; }

		public bool Status { get; set; }

		public User User { get; set; }
	}
}

