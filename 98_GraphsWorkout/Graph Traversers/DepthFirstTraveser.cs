using System;
using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class DepthFirstTraveser : IGraphTraverser
	{
		public void Traverse(Graph graph, int startNode = 0)
		{
			var stack = new Stack<Node>();
			stack.Push(graph.Nodes.First());
			while (stack.Count != 0)
			{
				var tempNode = stack.Pop();
				Console.WriteLine("Node number: " + tempNode.Index);
				var negibours = tempNode.Neighbors;
				foreach (var item in negibours)
					stack.Push(item);
			}
		}
	}
}