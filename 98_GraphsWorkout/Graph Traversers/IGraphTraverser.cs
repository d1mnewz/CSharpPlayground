using System.Collections.Generic;

namespace _98_GraphsWorkout
{
	public interface IGraphTraverser
	{
		IEnumerable<int> Traverse(Graph graph, int startNode = 0);
	}
}