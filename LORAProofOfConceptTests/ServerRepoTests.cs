using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LORAProofOfConcept.Server.Repository;
using System.Collections.Generic;
using LORAProofOfConcept.Core.Model;

namespace LORAProofOfConceptTests
{
	[TestClass]
	public class ServerRepoTests
	{
		[TestMethod]
		public void TestMemoryRepositoryEmpty()
		{
			var repo = new MemoryGarbageBinRepository();

			Assert.AreEqual(0, repo.GetGarbageBins().Count);
			Assert.ThrowsException<KeyNotFoundException>(() => {
				repo.GetGarbageBin("nonexistentid");
			});
		}

		[TestMethod]
		public void TestMemoryRepositoryInsert()
		{
			var repo = new MemoryGarbageBinRepository();

			var bin = new GarbageBin("1", "2", 100);
			var ID = bin.ID;
			repo.Save(bin);

			var retrievedBin = repo.GetGarbageBin(ID);

			Assert.AreSame(bin, retrievedBin);
			Assert.AreEqual(ID, retrievedBin.ID);
		}

		[TestMethod]
		public void TestMemoryRepositoryUpdate()
		{
			var repo = new MemoryGarbageBinRepository();

			var bin = new GarbageBin("1", "2", 100);
			var ID = bin.ID;
			repo.Save(bin);

			bin.CurrentCapacity = 20;
			repo.Save(bin);

			var retrievedBin = repo.GetGarbageBin(ID);

			Assert.AreSame(bin, retrievedBin);
			Assert.AreEqual(ID, retrievedBin.ID);
			Assert.AreEqual(20, retrievedBin.CurrentCapacity);
		}

		[TestMethod]
		public void TestMemoryRepositoryDelete()
		{
			var repo = new MemoryGarbageBinRepository();

			var bin = new GarbageBin("1", "2", 100);
			var ID = bin.ID;
			repo.Save(bin);

			repo.Delete(bin);

			var bins = repo.GetGarbageBins();

			Assert.AreEqual(0, bins.Count);
			Assert.ThrowsException<KeyNotFoundException>(() => {
				repo.GetGarbageBin(ID);
			});
		}

		[TestMethod]
		public void TestMemoryRepositoryGetAllBins()
		{
			var repo = new MemoryGarbageBinRepository();

			var bin1 = new GarbageBin("1", "2", 100);
			var bin2 = new GarbageBin("3", "4", 200);

			repo.Save(bin1);
			repo.Save(bin2);

			var bins = repo.GetGarbageBins();

			Assert.AreEqual(2, bins.Count);
			Assert.AreSame(bin1, bins[bin1.ID]);
		}
	}
}
