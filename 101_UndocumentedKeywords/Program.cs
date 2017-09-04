using System;

namespace _101_UndocumentedKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
			double value = 10;
	        TypedReference typedReference = __makeref(value); // typedReference = &value;
	        Console.WriteLine(__refvalue(typedReference, double)); // 10
	        __refvalue(typedReference, double) = 11; // *typedReference = 11
	        Console.WriteLine(__refvalue(typedReference, double)); // 11
	        Type type = __reftype(typedReference); // value.GetType()
	        Console.WriteLine(type.Name); // Double
	        Run();
        }

	    private static void Run()
	    {
		    Foo(__arglist(1, 2.0, "3", new int[0]));
	    }

	    public void Foo(__arglist)
	    {
		    var iterator = new ArgIterator(__arglist);
		    while (iterator.GetRemainingCount() > 0)
		    {
			    TypedReference typedReference = iterator.GetNextArg();
			    Console.WriteLine("{0} / {1}",
				    TypedReference.ToObject(typedReference),
				    TypedReference.GetTargetType(typedReference));
		    }
	    }
	}
}