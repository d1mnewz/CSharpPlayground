using System;
using System.Collections.Generic;

namespace _99_Sortings
{
    public interface ISorter
    {
        IList<T> Sort<T>(IList<T> toSort, bool asc = true) where T : IComparable<T>;
    }
}