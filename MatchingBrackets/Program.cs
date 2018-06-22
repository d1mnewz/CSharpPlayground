using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
	class Program
	{
		static void Main(string[] args)
		{
			var data = "{[({[()]})]}";

			Console.WriteLine($"{data}");

			var service = new DelimitersMatchService(new List<Delimiter>
			{
				new Delimiter {OpeningSymbol = '{', ClosingSymbol = '}'},
				new Delimiter {OpeningSymbol = '[', ClosingSymbol = ']'},
				new Delimiter {OpeningSymbol = '(', ClosingSymbol = ')'},
			});
			var result = service.IsCorrect(data);
			Console.WriteLine(result);
			Console.ReadKey();
		}
	}


}