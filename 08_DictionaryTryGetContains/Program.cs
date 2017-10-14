using System;
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
}
