using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using uhttpsharp.Listeners;
using uhttpsharp;
using uhttpsharp.RequestProviders;
using System.Net.Sockets;
using LORAProofOfConcept.Core;

namespace LORAProofOfConcept
{
	class Program
	{
		static void Main(string[] args)
		{
			var bins = new Dictionary<string, GarbageBin>();

			var handler = new LoraRequestHandler(bins);

			using (var httpServer = new HttpServer(new HttpRequestProvider()))
			{
				httpServer.Use(new TcpListenerAdapter(new TcpListener(IPAddress.Loopback, 80)));

				// Request handling : 
				httpServer.Use((context, next) => {
					Console.WriteLine("Incoming HTTP request");

					handler.HandleRequest(context);

					return next();
				});

				// Workaround for null reference exceptions when not enough handlers are registered
				httpServer.Use((context, next) => Task.Factory.GetCompleted());

				httpServer.Start();

				Console.ReadLine();
			}
		}
	}
}
