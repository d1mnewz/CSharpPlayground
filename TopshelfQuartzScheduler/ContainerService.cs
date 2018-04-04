namespace TopshelfQuartzScheduler
{
	public class ContainerService : IWindowsService
	{
		public bool Start()
		{
			return true;
		}

		public bool Stop()
		{
			return true;
		}
	}
}