using System;
using System.Threading;

namespace _07_ThreadPool
{
	class Program
	{
		/// <summary>
		/// The ThreadPool keeps a cache of  threads because threads are expensive to create.
		/// So don't create any Thread in your code!
		/// ThreadPool is a part of CLR that contains two kinds of threads - worker threads (CPU Bound) and IO Completein Port.
		/// 100 worker threads &amp; 100 IOCP threads per logical processor.
		/// E.g. I have 2 core physical processor with HyperThreading-on which means I have 4 logical processors.
		/// ASP.NET sets the maximum number of worker and I/O threads to 100 per processor.
		/// So I expect to have 400 worker threads and 400 iocp threads by default in ASP.NET.
		/// </summary>
		static void Main()
		{
			var logicalProcessorCount = Environment.ProcessorCount;
			ThreadPool.GetMinThreads(out var minimumWorkerThreadCount, out var minimumIocThreadCount);
			ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxIocThreads);
			ThreadPool.GetAvailableThreads(out var availableWorkerThreads, out var availableIocThreads);
			Console.WriteLine($"No.of processors: {logicalProcessorCount}");
			Console.WriteLine($"Minimum no.of Worker threads: {minimumWorkerThreadCount}");
			Console.WriteLine($"Minimum no.of IOCP threads: {minimumIocThreadCount}");
			Console.WriteLine($"Available no.of Worker threads: {availableWorkerThreads}");
			Console.WriteLine($"Available no.of IOCP threads: {availableIocThreads}");
			Console.WriteLine($"Max no.of Worker threads: {maxWorkerThreads}");
			Console.WriteLine($"Max no.of IOCP threads: {maxIocThreads}");
			Console.Read();
		}
	}
}
