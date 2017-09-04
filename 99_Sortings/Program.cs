using System.Collections.Generic;
using static System.Console;

namespace _99_Sortings
{
    public class Program
    {
        public static void Main()
        {
            var sort = new List<int>{ -43, 123, 43,23, 123, 92, 1, 0, 32, 85, 4};
            var bs = new BubbleSorter();

            var res = bs.Sort(toSort: sort, asc: false);

            WriteLine(res);
        }
    }
}