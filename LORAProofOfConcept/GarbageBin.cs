using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORAProofOfConcept
{
	class GarbageBin
	{
		public string ID { get; set; }

		public string Latitude { get; private set; }

		public string Longitude { get; private set; }

		/// <summary>
		/// The maximum volume that this bin can hold.
		/// </summary>
		public int MaxCapacity { get; private set; }

		/// <summary>
		/// The volume that this bin currently holds.
		/// </summary>
		public int CurrentCapacity { get; set; }

		/// <summary>
		/// How full this bin is, in percentage.
		/// </summary>
		public decimal FullPercentage
		{
			get
			{
				return ((decimal)CurrentCapacity / (decimal)MaxCapacity) * 100;
			}
		}

		public GarbageBin(string lat, string lon, int capacity)
		{
			this.ID = Guid.NewGuid().ToString("N");

			this.Latitude = lat;
			this.Longitude = lon;
			this.MaxCapacity = capacity;
			this.CurrentCapacity = 0;
		}
	}
}
