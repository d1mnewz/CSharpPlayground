using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class DepthFirstTraveser : IGraphTraverser
	{

		IEnumerable<int> IGraphTraverser.Traverse(Graph graph, int startNode)
		{
			var resultingSequence = new List<int>();
			var stack = new Stack<Node>();
			stack.Push(graph.Nodes.ElementAt(startNode));
			while (stack.Count != 0)
			{
				var tempNode = stack.Pop();
				resultingSequence.Add(tempNode.Index);
				var negibours = tempNode.Neighbors;
				foreach (var item in negibours)
					stack.Push(item);
			}
			return resultingSequence;
		}
	}
}