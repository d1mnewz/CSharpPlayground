namespace _11_Singleton
{
	public sealed class SingletonStaticInit
	{
		private static readonly SingletonStaticInit _instance = new SingletonStaticInit();

		public static SingletonStaticInit Instance => _instance;
	}
}