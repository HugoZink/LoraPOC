using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LORAProofOfConcept.Core.Model;
using LORAProofOfConcept.Core.Repository;

namespace LORAProofOfConcept.Server.Repository
{
	public class MemoryGarbageBinRepository : IGarbageBinRepository
	{
		private Dictionary<string, GarbageBin> bins;

		public MemoryGarbageBinRepository()
		{
			this.bins = new Dictionary<string, GarbageBin>();
		}

		public GarbageBin GetGarbageBin(string id)
		{
			if(!this.bins.ContainsKey(id))
			{
				throw new KeyNotFoundException("A garbage bin with this ID could not be found!");
			}

			return this.bins[id];
		}

		public Dictionary<string, GarbageBin> GetGarbageBins()
		{
			return this.bins;
		}

		public void Save(GarbageBin bin)
		{
			if(!this.bins.ContainsKey(bin.ID))
			{
				// Bin does not exist yet, add a new one.
				this.bins.Add(bin.ID, bin);
			}
			else
			{
				// Bin already exists, update it.
				this.bins[bin.ID] = bin;
			}
		}

		public void Delete(GarbageBin bin)
		{
			this.bins.Remove(bin.ID);
		}
	}
}
