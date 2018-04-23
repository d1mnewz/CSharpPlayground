using System;

namespace MaxSquareAreaRectangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 2, 3, 4, 2 };
			Console.WriteLine(GetRectangleMaxSquareAreaForHistogramDP(arr));
			Console.WriteLine("Hello World!");
			Console.Read();
		}

		public static int GetRectangleMaxSquareAreaForHistogramDP(int[] height)
		{
			var n = height.Length;
			if (n == 0) return 0;
			var dp = new int[n, n];
			var max = -1;

			for (var width = 1; width <= n; width++)
			{
				for (var l = 0; l + width - 1 < n; l++)
				{
					var r = l + width - 1;

					if (width == 1)
					{
						dp[l, l] = height[l];
						max = Math.Max(max, dp[l, l]);
					}
					else
					{
						dp[l, r] = Math.Max(dp[l, r - 1], height[r]);
						max = Math.Max(max, dp[l, r] * width);
					}
				}
			}

			return max;
		}
	}
}