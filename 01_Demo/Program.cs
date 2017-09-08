using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace _01_Demo
{
	internal class Program
	{
		public static async Task Main()
		{
			WriteLine("hello");
			object[] arr = { "Dmytro", -42, "42", 420, new LockCookie(), new object[] { -420, 23, 17 } };
			await PrintTypes(arr);

		}

		private static async Task PrintTypes(object[] arr,
			CancellationToken cancellationToken = default,
			DateTimeOffset calculationDate = default)
		{
			foreach (var obj in arr)
			{
				switch (obj)
				{
					case int i when i < 0:
						WriteLine($"{i} is {i.GetType().Name} < 0");
						break;
					case int i when i >= 0:
						WriteLine($"{i} is {i.GetType().Name} >= 0");
						break;
					case string str when Int32.TryParse(str, out _):
						WriteLine($"{str} is {str.GetType().Name}, but may be parsed as int");
						break;
					case string str when !Int32.TryParse(str, out _):
						WriteLine($"{str} is {str.GetType().Name} and can't be parsed as int");
						break;
					case object[] objArr when objArr.Length > 0:
						await PrintTypes(objArr, cancellationToken);
						break;
					case null:
						break;
					default:
						throw new ArgumentException("Invalid parameter", nameof(obj));
				}
			}
		}
	}
}