using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _08_DictionaryTryGetContains
{
	class Program
	{
		static void Main()
		{
			var dpr = new DictionaryPerformanceRunner();
			long contains;
			long tryget;

			var sw = Stopwatch.StartNew();
			for (int i = 0; i < 100; i++)
			{

				dpr.UsingContainsKey();

			}
			contains = sw.ElapsedTicks;

			var sw1 = Stopwatch.StartNew();
			for (int i = 0; i < 100; i++)
			{
				dpr.UsingTryGetValue();
			}
			tryget = sw1.ElapsedTicks;
			Console.WriteLine($"Contains 100 runs on 1000000 length dictionary {contains / TimeSpan.TicksPerMillisecond}ms");
			Console.WriteLine($"TryGetValue 100 runs on 1000000 length dictionary {tryget / TimeSpan.TicksPerMillisecond}ms");
			Console.WriteLine($"TryGetValue is { 100 - Math.Round(tryget / (double)contains * 100, 2)} % faster than Contains");
		}

	}

	public class DictionaryPerformanceRunner
	{
		private const int Size = 1000000;

		private readonly Dictionary<int, string> _dictionary;

		public DictionaryPerformanceRunner()
		{
			_dictionary = new Dictionary<int, string>();

			for (var i = 0; i < Size; i++)
			{
				_dictionary.Add(i, i.ToString());
			}
		}


		public string UsingContainsKey()
		{
			var result = string.Empty;
			for (var i = 0; i < Size; i++)
			{
				if (_dictionary.ContainsKey(i))
				{
					result = _dictionary[i];
				}
			}
			return result;
		}

		public string UsingTryGetValue()
		{
			var result = string.Empty;
			for (var i = 0; i < Size; i++)
			{
				_dictionary.TryGetValue(i, out result);
			}
			return result;
		}
	}
}
