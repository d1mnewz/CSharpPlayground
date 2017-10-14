using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _06_TPLPlayground
{
	class Program
	{
		public static async Task Main()
		{
			Foo f = new Foo();
			for (int i = 0; i < 100; i++)
			{
				await f.SomeOperationAsync();
			}

		}
		~Program()
		{
			throw new NotImplementedException();
		}

	}

	public class Foo
	{
		private void SomeOperation()
		{
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
		}

		public async Task SomeOperationAsync()
		{
			Task t = new Task(SomeOperation);
			t.Start();
			await t;
		}

	}
}

