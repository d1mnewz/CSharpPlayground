using System.Collections.Generic;
using static System.Console;

namespace _99_Sortings
{
	public class Program
	{
		public static void Main()
		{
			var list = new List<int> { -43, 123, 43, 23, 123, 92, 1, 0, 32, 85, 4 };
			var sorters = new ISorter[] { new QuickSorter(), new BubbleSorter() };
			foreach (var sorter in sorters)
			{
				sorter.Sort(list);
				foreach (var i in list)
				{
					Write($"{i} ");
				}
				WriteLine();
			}
			ReadKey();
		}
	}
}