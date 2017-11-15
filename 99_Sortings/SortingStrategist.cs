using System;
using System.Collections.Generic;

namespace _99_Sortings
{
	public class SortingStrategist
	{
		public void ChangeAlgorithm(ISorter sorter)
		{
			if (sorter is null) return;
			_sorter = sorter;
		}

		private ISorter _sorter;

		public IList<T> Sort<T>(IList<T> toSort) where T : IComparable<T>
		{
			toSort = _sorter.Sort(toSort);
			return toSort;
		}
	}
}