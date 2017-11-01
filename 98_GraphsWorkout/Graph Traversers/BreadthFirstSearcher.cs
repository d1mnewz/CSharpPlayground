using System;
using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class BreadthFirstTraverser : IGraphTraverser
	{
		public void Traverse(Graph graph, int startNode = 0)
		{
			var queue = new Queue<Node>();
			queue.Enqueue(graph.Nodes.First());
			while (queue.Count > 0)
			{
				var tempNode = queue.Dequeue();
				Console.WriteLine("Node number: " + tempNode.Index);
				foreach (var item in tempNode.Neighbors)
					queue.Enqueue(item);
			}
		}
	}
}