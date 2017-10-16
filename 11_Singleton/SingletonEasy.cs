namespace _11_Singleton
{
	public sealed class SingletonEasy
	{
		private static SingletonEasy _instance;

		public static SingletonEasy Instance =>
			_instance ?? (_instance = new SingletonEasy());
	}
}