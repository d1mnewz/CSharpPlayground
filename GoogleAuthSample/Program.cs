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
//				ApplicationName = "Maneno",
//				ApiKey = "46114941870-tur24h3f1f0ib16ap9gqvaoj879il06l.apps.googleusercontent.com",
				HttpClientInitializer = credentials
			});
			var user = service.Userinfo.V2.Me.Get().Execute();
//			return Task.FromResult(new User
//			{
//				Email = user.Email,
//				FirstName = user.GivenName,
//				LastName = user.FamilyName,
//				Name = user.Name,
//				UserName = user.Email
//			});
		}
	}
}