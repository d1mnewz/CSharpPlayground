namespace _11_Singleton
{
	public sealed class SingletonThreadSafe
	{
		private static readonly object _synchronizationObject = new object();
		private static volatile SingletonThreadSafe _instance;

		static SingletonThreadSafe()
		{
		}

		private SingletonThreadSafe()
		{
		}

		public static SingletonThreadSafe Instanse
		{
			get
			{
				if (_instance == null)
				{
					lock (_synchronizationObject)
					{
						if (_instance == null)
							return _instance = new SingletonThreadSafe();
					}
				}
				return _instance;
			}
		}
	}
}