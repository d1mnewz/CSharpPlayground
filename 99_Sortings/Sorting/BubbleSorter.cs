using System;
using System.Collections.Generic;

namespace _99_Sortings
{
    public class BubbleSorter : ISorter
    {
        // ReSharper disable once FlagArgument
        public IList<T> Sort<T>(IList<T> toSort, bool asc = true)
            where T : IComparable<T>
        {
	        var length = toSort.Count - 1;
            if (length <= 1)
                return toSort;
            if (asc)
            {
                for (var i = 1; i < length; i++)
                    for (var j = 0; j < length; j++)
                        if (toSort[j].CompareTo(toSort[j + 1]) > 0)
                        {
                            var tmp = toSort[j];
                            toSort[j] = toSort[j + 1];
                            toSort[j + 1] = tmp;
                        }
            }
            else
            {
                for (var i = 1; i < length; i++)
                    for (var j = 0; j < length; j++)
                        if (toSort[j].CompareTo(toSort[j + 1]) < 0)
                        {
                            var tmp = toSort[j];
                            toSort[j] = toSort[j + 1];
                            toSort[j + 1] = tmp;
                        }
            }
            return toSort;
        }
    }
}