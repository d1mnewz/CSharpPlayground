using System.Web.Http;

namespace _14_DynamicModel.Controllers
{
	public class ValuesController : ApiController
	{
		// POST api/values
		[HttpPost]
		public dynamic PostDynamic(dynamic value)
		{
			return value.hello;
		}
	}
}
