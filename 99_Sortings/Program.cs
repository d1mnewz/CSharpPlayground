using System.Collections.Generic;
using static System.Console;

namespace _99_Sortings
{
	public class Program
	{
		public static void Main()
		{
			IList<int> list = new List<int> { -43, 123, 43, 23, 123, 92, 1, 0, 32 }; // implement memento for list
			var sorters = new ISorter[] { new MergeSorter(), new QuickSorter(), new BubbleSorter() };
			var strategist = new SortingStrategist();
			foreach (var sorter in sorters)
			{
				strategist.ChangeAlgorithm(sorter);
				list = strategist.Sort(list);
				foreach (var i in list)
				{
					Write($"{i} ");
				}
				WriteLine();
				list = new List<int> { -43, 123, 43, 23, 123, 92, 1, 0, 32}; // implement memento for list
			}
			ReadKey();
		}
	}
}