using System;
using System.Collections.Generic;
using System.Linq;

namespace _98_GraphsWorkout
{
	public class Program
	{
		static void Main()
		{

			var graph = new Graph();
			graph.Add(new Node(0));
			graph.Nodes.ElementAt(0).AddNeighbor(1);
			graph.Nodes.ElementAt(0).AddNeighbor(2);
			graph.Nodes.ElementAt(0).Neighbors.ElementAt(0).AddNeighbor(3);

			var traversers = new List<IGraphTraverser> { new BreadthFirstTraverser(), new DepthFirstTraveser() };

			foreach (var graphTraverser in traversers)
			{
				Console.WriteLine(graphTraverser.GetType().Name);
				graphTraverser.Traverse(graph);
			}
		}
	}
}
