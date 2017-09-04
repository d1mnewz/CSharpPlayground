using System;
using static System.Console;

namespace _03_FunctionalErrorHandling
{
	class Program
	{
		static void Main()
		{
			WriteLine(
				Promote(10));
		}

		private static string Promote(long id)
		{
			var gateway = new EmailGateway();

			return GetById(id)
				.Ensure(customer => customer.CanBePromoted(), "The customer has the highest status possible")
				.OnSuccess(customer => customer.Promote())
				.OnSuccess(customer => gateway.SendPromotionNotification(customer.Email))
				.OnBoth(result => result.Success ? "Ok" : result.Error);
		}

		private static Result<Customer> GetById(long id)
			=> new Result<Customer>(new Customer(), true, String.Empty);


	}
}
