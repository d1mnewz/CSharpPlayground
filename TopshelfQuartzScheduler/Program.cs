using System;
using System.Threading.Tasks;
using Quartz;
using Topshelf;
using Topshelf.Quartz;

namespace TopshelfQuartzScheduler
{
	internal static class Program
	{
		public static async Task Main()
		{
			HostFactory.Run(x =>
			{
				x.Service<ContainerService>(s =>
				{
					s.WhenStarted(service => service.Start());
					s.WhenStopped(service => service.Stop());
					s.ConstructUsing(() => new ContainerService());

					s.ScheduleQuartzJob(q =>
						q.WithJob(() =>
								JobBuilder.Create<HelloJob>().Build())
							.AddTrigger(() => TriggerBuilder.Create()
								.WithSimpleSchedule(b => b
									.WithIntervalInSeconds(10)
									.RepeatForever())
								.Build()));
				});

				x.RunAsLocalService()
					.DependsOnEventLog()
					.StartAutomatically()
					.EnableServiceRecovery(rc => rc.RestartService(1));

				x.SetServiceName("My Topshelf Service");
				x.SetDisplayName("My Topshelf Service");
				x.SetDescription("My Topshelf Service's description");
			});
			Console.ReadLine();
		}
	}
}