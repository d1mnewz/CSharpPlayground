using System;
using System.Threading;

namespace _07_ThreadPool
{
    class Program
    {
        static void Main()
        {
	        var logicalProcessorCount = System.Environment.ProcessorCount;
	        ThreadPool.GetMinThreads(out var minimumWorkerThreadCount, out var minimumIocThreadCount);
	        Console.WriteLine($"No.of processors: {logicalProcessorCount}");
	        Console.WriteLine($"Minimum no.of Worker threads: {minimumWorkerThreadCount}");
	        Console.WriteLine($"Minimum no.of IOCP threads: {minimumIocThreadCount}");
	        Console.Read();
		}
    }
}
