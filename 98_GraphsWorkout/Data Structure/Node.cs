using System.Collections.Generic;

namespace _98_GraphsWorkout
{
	public class Node
	{
		public int Index { get; set; }
		private readonly IList<Node> _neighbors;
		public IEnumerable<Node> Neighbors => _neighbors;
		public Node(int index)
		{
			Index = index;
			_neighbors = new List<Node>();
		}
		public void AddNeighbor(int index)
		{
			_neighbors.Add(new Node(index));
		}
	}
}