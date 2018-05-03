using System;
using System.Linq;

namespace TopCoderProblemsA
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine(StringAdjustedDuplicatesRemover.RemoveAdjustedDuplicates("abba"));
			Console.WriteLine(StringAdjustedDuplicatesRemover.RemoveAdjustedDuplicates("zwwwzffw"));
			Console.WriteLine(StringAdjustedDuplicatesRemover.RemoveAdjustedDuplicates("rrrrrrr"));
			Console.WriteLine(StringAdjustedDuplicatesRemover.RemoveAdjustedDuplicates("dfghj"));
			Console.WriteLine(StringAdjustedDuplicatesRemover.RemoveAdjustedDuplicates("wasitacarooracatisaw"));
			
		}
	}

	public class StringAdjustedDuplicatesRemover
	{
		public static int RemoveAdjustedDuplicates(string input)
		{
			var counter = 0;
			var chars = input.ToArray();
			var currentPositionWhileNoMatch = 0;

			for (var i = 0; i < chars.Length; i++)
			{
				if (currentPositionWhileNoMatch is 0 || chars[i] != chars[currentPositionWhileNoMatch - 1])
					chars[currentPositionWhileNoMatch++] = chars[i];
				else
				{
					counter++;
					currentPositionWhileNoMatch--;
				}
			}

			return counter;
		}
	}
}