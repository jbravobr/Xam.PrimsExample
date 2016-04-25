using System;

namespace IcatuzinhoApp
{
	public class User : BaseEntity
	{
		public string Email { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }
	}
}

