using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LORAProofOfConcept.Core.Model;

namespace LORAProofOfConcept.Core.Repository
{
	public interface IGarbageBinRepository
	{
		/// <summary>
		/// Get all garbage bins.
		/// </summary>
		/// <returns>A Dictionary containing the found garbage bins.</returns>
		Dictionary<string, GarbageBin> GetGarbageBins();

		/// <summary>
		/// Get a single garbage bin by ID.
		/// </summary>
		/// <param name="id">The ID to search by.</param>
		/// <returns>A single garbage bin instance.</returns>
		/// <throws>A KeyNotFoundException if the garbage bin was not found.</throws>
		GarbageBin GetGarbageBin(string id);

		/// <summary>
		/// Creates or updates a garbage bin.
		/// </summary>
		/// <param name="bin">The garbage bin to update.</param>
		void Save(GarbageBin bin);

		/// <summary>
		/// Deletes a bin from the list.
		/// </summary>
		/// <param name="bin">The bin to delete.</param>
		void Delete(GarbageBin bin);
	}
}
