using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace _09_ThreadPoolAspCore.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		[HttpGet]
		public IEnumerable<int> Get()
		{
			
			var logicalProcessorCount = Environment.ProcessorCount;
			//ThreadPool.SetMinThreads(100, 100);
			ThreadPool.GetMinThreads(out var minimumWorkerThreadCount, out var minimumIocThreadCount);
			ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxIocThreads);
			ThreadPool.GetAvailableThreads(out var availableWorkerThreads, out var availableIocThreads);
			Console.WriteLine($"No.of processors: {logicalProcessorCount}"); // physical cores * 2 (if hyperthreading is on)
			Console.WriteLine($"Minimum no.of Worker threads: {minimumWorkerThreadCount}"); // logicalProcessorCount by default
			Console.WriteLine($"Minimum no.of IOCP threads: {minimumIocThreadCount}"); // logicalProcessorCount by default
			Console.WriteLine($"Available no.of Worker threads: {availableWorkerThreads}"); // short.MaxValue - x where x is count of threads taken for request
			Console.WriteLine($"Available no.of IOCP threads: {availableIocThreads}"); // 1000 by default
			Console.WriteLine($"Max no.of Worker threads: {maxWorkerThreads}"); // short.MaxValue
			Console.WriteLine($"Max no.of IOCP threads: {maxIocThreads}"); // 1000 by default
			return new[] { short.MaxValue, logicalProcessorCount,
				minimumIocThreadCount, minimumWorkerThreadCount,
				availableWorkerThreads, availableIocThreads,
				maxWorkerThreads, maxIocThreads
			};
		}

	}
}
