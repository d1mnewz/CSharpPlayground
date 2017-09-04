using System;

namespace _102_UndocumentedKeywords
{
	internal class Program
	{
		/// <summary>
		/// These keywords used to be undocumented, but for now even ReSharper recognizes them. 
		/// __makeref, __refvalue, __reftype, __arglist
		/// </summary>
		private static void Main()
		{
			double value = 10;
			var typedReference = __makeref(value); // typedReference = &value;
			Console.WriteLine(__refvalue(typedReference, double)); // 10
			__refvalue(typedReference, double) = 11; // *typedReference = 11
			Console.WriteLine(__refvalue(typedReference, double)); // 11
			var type = __reftype(typedReference); // value.GetType()
			Console.WriteLine(type.Name); // Double
			Run();
		}

		private static void Run()
		{
			Foo(__arglist(1, 2.0, "3", new int[0]));
		}

		private static void Foo(__arglist)
		{
			var iterator = new ArgIterator(__arglist);
			while (iterator.GetRemainingCount() > 0)
			{
				var typedReference = iterator.GetNextArg();
				Console.WriteLine($"{TypedReference.ToObject(typedReference)} " +
				                  $"/ {TypedReference.GetTargetType(typedReference)}");
			}
		}
	}
}