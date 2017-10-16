using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace _10_Threads.Controllers
{
	public class ValuesController : ApiController
	{
		/// <summary>
		/// Basics of multithreading 
		/// this method would be executed on different threads.
		/// </summary>
		public async Task<IEnumerable<int>> Get()
		{
			var dummy = Thread.CurrentThread.ManagedThreadId;
			var webClient = new WebClient();
			await webClient.DownloadStringTaskAsync("https://google.com");
			var dummy2 = Thread.CurrentThread.ManagedThreadId;

			return new[] { dummy, dummy2 };
		}


	}
}
