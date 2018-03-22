using LORAProofOfConcept.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORAProofOfConcept.Server.Repository
{
	public static class RepositoryFactory
	{
		public static IGarbageBinRepository GetRepository()
		{
			return new MemoryGarbageBinRepository();
		}
	}
}
