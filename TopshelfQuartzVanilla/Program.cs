using System;
using Quartz;
using Topshelf;
using Topshelf.HostConfigurators;
using Topshelf.Quartz;

namespace TopshelfQuartzVanilla
{
	internal class Program
	{
		public static void Main()
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
									.WithIntervalInSeconds(1)
									.RepeatForever().Build()
									)
								.Build()));
				});

				x.RunAsLocalSystem()
					.DependsOnEventLog()
					.StartAutomatically()
					.EnableServiceRecovery(rc => rc.RestartService(1));

				x.SetServiceName("MyTopshelf");
				x.SetDisplayName("MyTopshelf");
				x.SetDescription("MyTopshelf");
			});
			Console.ReadLine();
		}

		public interface IWindowsService
		{
			bool Start();
			bool Stop();
		}

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

		public class HelloJob : IJob
		{
			public void Execute(IJobExecutionContext context)
			{
				Console.WriteLine($"{DateTime.UtcNow.Date}");
			}
		}
	}
}