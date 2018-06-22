using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
	public class DelimitersMatchService : IDelimitersMatchService
	{
		private readonly List<Delimiter> _delimiters;

		public DelimitersMatchService(List<Delimiter> delimiters)
		{
			_delimiters = delimiters;
		}

		public bool IsCorrect(string data)
		{
			var stack = new Stack<char>();
			foreach (var character in data)
			{
				if (_delimiters.Select(x => x.OpeningSymbol).Contains(character))
				{
					stack.Push(character);
					continue;
				}

				if (_delimiters.Select(x => x.ClosingSymbol).Contains(character) &&
				    stack.Peek() ==
				    _delimiters.First(x => x.ClosingSymbol == character).OpeningSymbol)
				{
					stack.Pop();
					continue;
				}

				return false;
			}

			return stack.Count == 0;
		}
	}

	public class Delimiter
	{
		public char OpeningSymbol { get; set; }
		public char ClosingSymbol { get; set; }
	}

	internal interface IDelimitersMatchService
	{
		bool IsCorrect(string data);
	}
}