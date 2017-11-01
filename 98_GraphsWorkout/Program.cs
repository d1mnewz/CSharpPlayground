using System;
using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class Program
	{
		private static void Main()
		{
			//		  0
			//		1   2
			//    3
			var graph = new Graph();
			graph.Add(new Node(0));
			graph.Nodes.ElementAt(0).AddNeighbor(1);
			graph.Nodes.ElementAt(0).AddNeighbor(2);
			graph.Nodes.ElementAt(0).Neighbors.ElementAt(0).AddNeighbor(3);

			var traversers = new List<IGraphTraverser> { new BreadthFirstTraverser(), new DepthFirstTraveser() };

			foreach (var traverser in traversers)
			{
				Console.WriteLine(traverser.GetType().Name);
				traverser.Traverse(graph);
				// BFS: 0, 1, 2, 3
				// DFS: 0, 2, 1, 3
			}
		}
	}
}
