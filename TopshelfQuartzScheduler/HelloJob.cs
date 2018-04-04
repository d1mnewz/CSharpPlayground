using System;
using System.Threading.Tasks;
using Quartz;

namespace TopshelfQuartzScheduler
{
	public class HelloJob : IJob
	{
		public Task Execute(IJobExecutionContext context)
		{
			Console.WriteLine($"{DateTime.UtcNow.Date}");

			return Task.CompletedTask;
		}
	}
}