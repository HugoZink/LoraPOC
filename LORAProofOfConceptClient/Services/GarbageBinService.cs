using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LORAProofOfConcept.Core.Model;
using Newtonsoft.Json;

namespace LORAProofOfConceptClient.Services
{
	public class GarbageBinService
	{
		private const string remote = "http://127.0.0.1";

		public async Task<List<GarbageBin>> GetGarbageBins()
		{
			var client = new HttpClient();

			// Perform HTTP request
			HttpResponseMessage response = await client.GetAsync(remote);
			string json = await response.Content.ReadAsStringAsync();

			//Takes a JSON object containing more objects, and converts it to a list of objects.
			List<GarbageBin> bins = JsonConvert.DeserializeObject<Dictionary<string, GarbageBin>>(json).Values.ToList();

			return bins;
		}
	}
}
