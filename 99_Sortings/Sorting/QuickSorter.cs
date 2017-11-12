using System;
using System.Collections.Generic;

namespace _99_Sortings
{
	public class QuickSorter : ISorter
	{

		private IList<T> Sort<T>(IList<T> list, int left, int right) where T : IComparable<T>
		{
			if (left >= right) return list;

			var pivot = list[(left + right) / 2];
			var index = Partition(list, left, right, pivot);
			Sort(list, left, index-1);
			Sort(list, index, right);
			return list;
		}

		private int Partition<T>(IList<T> list, int left, int right, T pivot) where T : IComparable<T>
		{
			while (left <= right)
			{
				while (list[left].CompareTo(pivot) < 0)
					left++;
				while (list[right].CompareTo(pivot) > 0)
					right--;
				if (left <= right)
				{
					Swap(list, left, right);
					left++;
					right--;
				}
			}
			return left;
		}

		private void Swap<T>(IList<T> list, int left, int right)
		{
			var tmp = list[right];
			list[right] = list[left];
			list[left] = tmp;
		}

		public IList<T> Sort<T>(IList<T> toSort, bool asc = true) where T : IComparable<T>
		{
			return Sort(toSort, 0, toSort.Count - 1);
		}
	}
}