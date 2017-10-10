using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _05_ApiConcurrencyTestCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
	    // GET api/sync
	    [Route("api/sync")]
	    public void Get() => Thread.Sleep(TimeSpan.FromSeconds(5));

	    // GET api/async
	    [Route("api/async")]
	    public async Task GetAsync() => await Task.Delay(TimeSpan.FromSeconds(5));
	}
}
