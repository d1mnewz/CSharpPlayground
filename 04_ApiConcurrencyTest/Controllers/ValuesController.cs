using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace _04_ApiConcurrencyTest.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/sync
		[Route("api/sync")]
		public void Get() => Thread.Sleep(TimeSpan.FromSeconds(5));

		// GET api/async
		[Route("api/async")]
		public async Task GetAsync() => await Task.Delay(TimeSpan.FromSeconds(5));
	}
}
