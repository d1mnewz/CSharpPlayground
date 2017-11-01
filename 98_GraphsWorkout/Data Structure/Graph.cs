using System.Collections.Generic;

namespace _98_GraphsWorkout
{
	public class Graph
	{
		private IList<Node> _nodes { get; set; }
		public IEnumerable<Node> Nodes => _nodes;

		private int _size;

		public Graph()
		{
			this._nodes = new List<Node>();
			_size = 0;
		}

		public Graph(int count)
		{
			_nodes = new List<Node>(count);
			_size = count;
		}

		public void Add(Node node)
		{
			_nodes.Add(node);
		}
	}
}