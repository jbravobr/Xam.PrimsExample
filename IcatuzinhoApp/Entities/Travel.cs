using System;

namespace IcatuzinhoApp
{
	public class Travel : BaseEntity
	{
		public DateTime TravelTime { get; set; }

		public Driver Driver { get; set; }

		public Vehicle Vehicle { get; set; }
	}
}

