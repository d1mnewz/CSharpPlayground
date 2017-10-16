using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _12_LosingHttpContextConfigureAwait.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		/// <summary>
		/// In vanilla ASP.NET we lose HttpContext 
		/// because of configuring await not to continue on current synchronization context
		/// In ASP.NET Core it's OK.
		/// See 13_LosingHttpContextConfigureAwaitVanilla
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IEnumerable<HttpContext>> Get()
		{
			var ctx = HttpContext;
			await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
			var lostCtx = HttpContext;
			var eq = ctx == lostCtx;
			return new[] { ctx, lostCtx };
		}

	}
}
