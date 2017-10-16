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
		public async Task<IEnumerable<HttpContext>> Get()
		{
			var ctx = HttpContext.Current;
			await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
			//await Task.Delay(TimeSpan.FromSeconds(1)); This would save HttpContext and eq would be true.
			var lostCtx = HttpContext.Current; // If ConfigureAwait(false), then null
			var eq = ctx == lostCtx;
			return new[] { ctx, lostCtx };
		}
	}
}
