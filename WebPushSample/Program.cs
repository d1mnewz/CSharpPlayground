using System;
using WebPush;

namespace WebPushSample
{
	internal class Program
	{
		public static void Main()
		{
			var pushEndpoint =
				@"https://fcm.googleapis.com/fcm/send/eRoxpie1SyE:APA91bEs-q3RvgOU44dKOqaQDrNAOPQc6BMpn_wdmL0kSWd-ZY6X72LwUDU_0syzcKnU2ymdwFwr0cBAwpTBPT0of9UUVkY3yS_fGrIlflc7x50lV_Ut1N1PjmVy0Vk0wQyZct5tefO9";
			var p256dh = @"BNst5NFg14qt20FjL-npIx-qwSuiLNyzLZQQUBNM2utwIV5cb7DA6zSpxq0-pwjCZK8R217VlwN2VIApmiOQpmY";
			var auth = @"Bg72WKGBAIHf1-zJ54GzVA";

			var subject = @"mailto:example@example.com";
			var publicKey = @"BAINe9-vznpeHcvqae6Zg0i6edR96Whdh65Qp83FQnifTVTL2jP5oL7Q4Edvq9V1rdCFqnktRQ0vhwN-z-trfJ8";
			var privateKey = @"oVSUyM7AxK4bcCiSZpUg5Yqtb4zb5xJ5G9p3iX0C8_s";

			var subscription = new PushSubscription(pushEndpoint, p256dh, auth);
			var vapidDetails = new VapidDetails(subject, publicKey, privateKey);


			var webPushClient = new WebPushClient();
			try
			{
				webPushClient.SendNotification(subscription, "{ \"data\":{\"title\": \"hello\", \"content\": \"Euristiq\"}}", vapidDetails);
				//webPushClient.SendNotification(subscription, "payload", gcmAPIKey);
			}
			catch (WebPushException exception)
			{
				Console.WriteLine("Http STATUS code" + exception.StatusCode);
			}
		}
	}

	public class WebPushNotificationPayload
	{
//		public Payload Data {get}
	}
}