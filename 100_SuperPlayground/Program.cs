using System;

namespace _100_SuperPlayground
{

	class Range<T>
	{
		private readonly T _start;
		private readonly T _end;

		public Range(T start, T end)
		{
			_start = start;
			_end = end;
		}

		public T Start
		{
			get { return _start; }
		}

		public T End
		{
			get { return _end; }
		}

		public bool IsValid()
		{
			return _start <= _end;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new Range(1, 10).IsValid());
			Console.WriteLine(new Range(20, 5).IsValid());
			Console.ReadLine();
		}
	}
}
