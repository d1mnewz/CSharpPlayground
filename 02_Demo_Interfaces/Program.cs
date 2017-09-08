using Microsoft.Extensions.Logging;
using System;
using static System.Console;

namespace _02_Demo_Interfaces
{
	internal class Program
    {
	    private static void Main()
        {
            WriteLine("Hello World!");
        }
    }

	public interface ILogger
	{
		void Log(LogLevel level, string message);
		void Log(LogLevel level, string format, params object[] arguments);
		void Debug(string message);
		void Debug(string format, params object[] arguments);
		void Information(string message);
		void Information(string format, params object[] arguments);
		void Warning(string message);
		void Warning(string format, params object[] arguments);
		void Error(string message);
		void Error(string format, params object[] arguments);
	}

	public class ConsoleLogger : ILogger
	{
		public void Log(string message) => WriteLine(message);
	}

	public class FileLogger : ILogger
	{
		public void Log(string message)
		{
			throw new System.NotImplementedException();
		}

	}
}
