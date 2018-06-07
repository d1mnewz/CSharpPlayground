using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;

namespace GoogleAuthSample
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var accessToken =
				"ya29.GlvTBZnj-NGxW28OIE4jOjEsIQJh2XgxSsuDioj3VapUYeiT_D7TT6zwePEbOhLQ_dO0QlkRh5l_WX7fWm7oTnS75RWEk5OGN45tvheYwWyt0v0jexUSTO0bbETF";
			var credentials = GoogleCredential.FromAccessToken(
				accessToken);
			var service = new Oauth2Service(new BaseClientService.Initializer
			{
				HttpClientInitializer = credentials
			});
			var user = service.Userinfo.V2.Me.Get().Execute();
		}
	}
}