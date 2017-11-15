using System;
using System.Runtime.CompilerServices;

namespace _100_SuperPlayground
{
	public class Foo : IFoo
	{
		public int Dummy { get; set; }


		public override Foo default()
		{
			return new Foo { Dummy = 69 };
		}
	}

	interface IFoo
	{
		int Dummy { get; set; }
		IFoo default()
		{
			return new Foo
			{
				Dummy = 42
			};
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var foo = default(IFoo); // type is Foo, foo.Dummy is 42
			var Foo = default(Foo); // type is Foo, foo.Dummy is 69
		}
	}
}