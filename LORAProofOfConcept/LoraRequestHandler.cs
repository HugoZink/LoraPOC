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

namespace LORAProofOfConcept.Server
{
	class LoraRequestHandler
	{
		private IGarbageBinRepository _repository;

		public LoraRequestHandler(IGarbageBinRepository repository)
		{
			this._repository = repository;
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
	}
}
