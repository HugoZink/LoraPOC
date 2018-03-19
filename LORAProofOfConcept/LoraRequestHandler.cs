using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uhttpsharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LORAProofOfConcept
{
	class LoraRequestHandler
	{
		private Dictionary<string, GarbageBin> _bins;

		public LoraRequestHandler(Dictionary<string, GarbageBin> bins)
		{
			this._bins = bins;
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
			string json = JsonConvert.SerializeObject(this._bins);
			context.Response = new HttpResponse(HttpResponseCode.Ok, json, false);
		}

		private void HandleBinCreate(IHttpContext context)
		{
			var binDefinition = new { Latitude = "", Longitude = "", Capacity = 0 };

			var json = Encoding.ASCII.GetString(context.Request.Post.Raw);
			var bin = JsonConvert.DeserializeAnonymousType(json, binDefinition);

			var garbageBin = new GarbageBin(bin.Latitude, bin.Longitude, bin.Capacity);
			_bins.Add(garbageBin.ID, garbageBin);

			context.Response = new HttpResponse(HttpResponseCode.Ok, JsonConvert.SerializeObject(garbageBin), false);

			Console.WriteLine("Added bin");
		}

		private void HandleBinUpdate(IHttpContext context)
		{
			var binID = context.Request.RequestParameters[0];
			GarbageBin bin;

			if(_bins.ContainsKey(binID))
			{
				bin = _bins[binID];
			}
			else
			{
				throw new InvalidOperationException($"Bin with ID ${binID} could not be found!");
			}

			var definition = new { ID = "", CurrentCapacity = 0 };
			var json = Encoding.ASCII.GetString(context.Request.Post.Raw);

			var capacityData = JsonConvert.DeserializeAnonymousType(json, definition);

			bin.CurrentCapacity = capacityData.CurrentCapacity;

			context.Response = new HttpResponse(HttpResponseCode.Ok, JsonConvert.SerializeObject(bin), false);

			Console.WriteLine("Updated bin");
		}
	}
}
