using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class BreadthFirstTraverser : IGraphTraverser
	{

		IEnumerable<int> IGraphTraverser.Traverse(Graph graph, int startNode)
		{
			var resultingSequence = new List<int>();
			var queue = new Queue<Node>();
			queue.Enqueue(graph.Nodes.ElementAt(startNode));
			while (queue.Count > 0)
			{
				var tempNode = queue.Dequeue();
				resultingSequence.Add(tempNode.Index);
				foreach (var item in tempNode.Neighbors)
					queue.Enqueue(item);
			}
			return resultingSequence;
		}
	}
}