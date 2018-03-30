using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using LORAProofOfConcept.Core.Model;
using LORAProofOfConcept.Core.Repository;
using LORAProofOfConcept.Server.Repository;

namespace LORAProofOfConcept.Server.Services
{
	class LoraRequestHandler
	{
		private IGarbageBinRepository _repository;

		public LoraRequestHandler()
		{
			this._repository = RepositoryFactory.GetRepository();

			this.InsertTestData();
		}

		public void HandleRequest(IHttpContext context)
		{
			switch(context.Request.Method)
			{
				case HttpMethods.Get:
					this.HandleBinOverview(context);
					break;
				case HttpMethods.Post:
					this.HandleBinCreate(context);
					break;
				case HttpMethods.Put:
					this.HandleBinUpdate(context);
					break;
				case HttpMethods.Delete:
					this.HandleBinDelete(context);
					break;
				default:
					throw new InvalidOperationException("Unsupported HTTP request!");
			}
		}

		private void HandleBinOverview(IHttpContext context)
		{
			string json = JsonConvert.SerializeObject(this._repository.GetGarbageBins());
			context.Response = new HttpResponse(HttpResponseCode.Ok, json, false);
		}

		private void HandleBinCreate(IHttpContext context)
		{
			var binDefinition = new { Latitude = "", Longitude = "", Capacity = 0 };

			var json = Encoding.ASCII.GetString(context.Request.Post.Raw);
			var bin = JsonConvert.DeserializeAnonymousType(json, binDefinition);

			var garbageBin = new GarbageBin(bin.Latitude, bin.Longitude, bin.Capacity);
			this._repository.Save(garbageBin);

			context.Response = new HttpResponse(HttpResponseCode.Ok, JsonConvert.SerializeObject(garbageBin), false);

			Console.WriteLine("Added bin");
		}

		private void HandleBinUpdate(IHttpContext context)
		{
			var binID = context.Request.RequestParameters[0];
			GarbageBin bin = this._repository.GetGarbageBin(binID);

			var definition = new { ID = "", CurrentCapacity = 0 };
			var json = Encoding.ASCII.GetString(context.Request.Post.Raw);

			var capacityData = JsonConvert.DeserializeAnonymousType(json, definition);

			bin.CurrentCapacity = capacityData.CurrentCapacity;

			context.Response = new HttpResponse(HttpResponseCode.Ok, JsonConvert.SerializeObject(bin), false);

			Console.WriteLine("Updated bin");
		}

		private void HandleBinDelete(IHttpContext context)
		{
			var binID = context.Request.RequestParameters[0];
			GarbageBin bin = this._repository.GetGarbageBin(binID);

			this._repository.Delete(bin);

			context.Response = new HttpResponse(HttpResponseCode.Ok, JsonConvert.SerializeObject(bin), false);

			Console.WriteLine("Deleted bin");
		}

		/// <summary>
		/// Inserts sample test data into the repository.
		/// </summary>
		private void InsertTestData()
		{
			var random = new Random();

			// Insert random bins into the repository.
			for(int i = 0; i < 4; i++)
			{
				string lat = random.Next(0, 50).ToString();
				string lon = random.Next(0, 50).ToString();

				var bin = new GarbageBin(lat, lon, 100);
				bin.CurrentCapacity = random.Next(0, 100);
				this._repository.Save(bin);
			}

			// Insert one more garbage bin that is always 90% full.
			string fullLat = random.Next(0, 50).ToString();
			string fullLon = random.Next(0, 50).ToString();

			var fullBin = new GarbageBin(fullLat, fullLon, 100);
			fullBin.CurrentCapacity = 90;
			this._repository.Save(fullBin);
		}
	}
}
