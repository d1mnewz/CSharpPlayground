using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _13_LosingHttpContextConfigureAwaitVanilla.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		[HttpGet]
		public async Task<HttpContext> Get()
		{
			await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
			return HttpContext.Current;
		}
	}
}
