using System;
using System.Collections.Generic;
using System.Linq;

namespace _99_Sortings
{
	public class MergeSorter : ISorter
	{
		public IList<T> Sort<T>(IList<T> toSort, bool asc = true) where T : IComparable<T>
		{
			toSort = MergeSort(toSort);
			return toSort;
		}

		private IList<T> MergeSort<T>(IList<T> toSort) where T : IComparable<T>
		{
			if (toSort.Count <= 1) return toSort;

			IList<T> leftList = new List<T>();
			IList<T> rightList = new List<T>();
			var mid = toSort.Count / 2;

			for (int i = 0; i < mid; i++)
				leftList.Add(toSort[i]);
			for (int i = mid; i < toSort.Count; i++)
				rightList.Add(toSort[i]);

			leftList = MergeSort(leftList);
			rightList = MergeSort(rightList);
			toSort = Merge(leftList, rightList);
			return toSort;
		}

		private IList<T> Merge<T>(IList<T> left, IList<T> right) where T : IComparable<T>
		{
			var result = new List<T>();
			while (left.Any() && right.Any())
			{
				if (left.First().CompareTo(right.First()) <= 0)
				{
					result.Add(left.First());
					left.RemoveAt(0);
				}
				else
				{
					result.Add(right.First());
					right.RemoveAt(0);
				}
			}
			while (left.Any())
			{
				result.Add(left.First());
				left.RemoveAt(0);
			}
			while (right.Any())
			{
				result.Add(right.First());
				right.RemoveAt(0);
			}
			return result;
		}
	}
}