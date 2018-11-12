using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// 实现A*寻路算法
	/// </summary>
	class AStarPathfinding : IPathfinding
	{
		public override List<T> FindPath<T>(Dictionary<T, Dictionary<T, int>> edges, T originNode, T destinationNode)
		{
			IPriorityQueue<T> frontier = new HeapPriorityQueue<T>();
			frontier.Enqueue(originNode, 0);

			Dictionary<T, T> cameFrom = new Dictionary<T, T>();
			cameFrom.Add(originNode, default(T));
			Dictionary<T, int> costSoFar = new Dictionary<T, int>();
			costSoFar.Add(originNode, 0);

			while (frontier.Count != 0)
			{
				var current = frontier.Dequeue();
				if (current.Equals(destinationNode)) break;

				var neighbours = GetNeigbours(edges, current);
				foreach (var neighbour in neighbours)
				{
					var newCost = costSoFar[current] + edges[current][neighbour];
					if (!costSoFar.ContainsKey(neighbour) || newCost < costSoFar[neighbour])
					{
						costSoFar[neighbour] = newCost;
						cameFrom[neighbour] = current;
						var priority = newCost + Heuristic(destinationNode, neighbour);
						frontier.Enqueue(neighbour, priority);
					}
				}
			}

			List<T> path = new List<T>();
			if (!cameFrom.ContainsKey(destinationNode))
				return path;

			path.Add(destinationNode);
			var temp = destinationNode;

			while (!cameFrom[temp].Equals(originNode))
			{
				var currentPathElement = cameFrom[temp];
				path.Add(currentPathElement);

				temp = currentPathElement;
			}

			return path;
		}
		private int Heuristic<T>(T a, T b) where T : IGraphNode
		{
			return a.GetDistance(b);
		}
	}
}
