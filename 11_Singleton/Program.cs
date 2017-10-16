using System;

namespace _11_Singleton
{
	class Program
	{
		static void Main()
		{

			Console.WriteLine(SingletonStaticInit.Instance.GetHashCode());
			Console.WriteLine(SingletonStaticInit.Instance.GetHashCode());
			Console.WriteLine(SingletonStaticInit.Instance.GetHashCode());

			Console.WriteLine(SingletonEasy.Instance.GetHashCode());
			Console.WriteLine(SingletonEasy.Instance.GetHashCode());
			Console.WriteLine(SingletonEasy.Instance.GetHashCode());

			Console.WriteLine(SingletonThreadSafe.Instanse.GetHashCode());
			Console.WriteLine(SingletonThreadSafe.Instanse.GetHashCode());
			Console.WriteLine(SingletonThreadSafe.Instanse.GetHashCode());

			Console.WriteLine(SingletonLazy.Instance.GetHashCode());
			Console.WriteLine(SingletonLazy.Instance.GetHashCode());
			Console.WriteLine(SingletonLazy.Instance.GetHashCode());

			Console.WriteLine(SingletonThreadSafeWithMonitor.Instance.GetHashCode());
			Console.WriteLine(SingletonThreadSafeWithMonitor.Instance.GetHashCode());
			Console.WriteLine(SingletonThreadSafeWithMonitor.Instance.GetHashCode());

		}
	}
}

