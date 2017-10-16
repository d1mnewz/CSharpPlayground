using System;

namespace _11_Singleton
{
	public sealed class SingletonLazy
	{
		private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>();
		public static SingletonLazy Instance => _instance.Value;
	}
}