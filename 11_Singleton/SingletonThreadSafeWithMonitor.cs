using System.Threading;

namespace _11_Singleton
{
	public sealed class SingletonThreadSafeWithMonitor
	{
		private static object syncObject = new object();

		private static SingletonThreadSafeWithMonitor _instance = null;

		public static SingletonThreadSafeWithMonitor Instance
		{
			get
			{
				if (_instance != null) return _instance;

				Monitor.Enter(syncObject);
				var tmp = new SingletonThreadSafeWithMonitor();
				Interlocked.Exchange(ref _instance, tmp); // atomic operation
				Monitor.Exit(syncObject);
				return _instance;
			}
		}

	}
}