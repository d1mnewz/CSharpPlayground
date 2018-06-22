using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MatchingBrackets.Tests
{
	public class DelimitersMatchServiceShould
	{
		private readonly DelimitersMatchService _sut;

		public DelimitersMatchServiceShould()
		{
			_sut = new DelimitersMatchService(new List<Delimiter>
			{
				new Delimiter {OpeningSymbol = '{', ClosingSymbol = '}'},
				new Delimiter {OpeningSymbol = '[', ClosingSymbol = ']'},
				new Delimiter {OpeningSymbol = '(', ClosingSymbol = ')'},
			});
		}

		[Theory]
		[InlineData("{[({[()]})]}", true)]
		[InlineData("{}", true)]
		[InlineData("({})", true)]
		[InlineData("[{()}]", true)]
		[InlineData("{)", false)]
		[InlineData("({[})", false)]
		[InlineData("[{()}", false)]
		public void ReturnCorrectResult(string data, bool expected)
		{
			_sut.IsCorrect(data).Should().Be(expected);
		}
	}
}