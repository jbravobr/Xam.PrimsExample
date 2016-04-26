using System;

namespace IcatuzinhoApp
{
	public class Station : BaseEntity
	{
		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }

		public string Name { get; set; }

		public int Order { get; set; }
	}
}

