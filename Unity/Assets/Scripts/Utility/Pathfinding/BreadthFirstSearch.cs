using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// 广度优先搜索算法的实现。它在这个项目中没有使用
	/// 我只是想尝试一下
	/// </summary>
	class BreadthFirstSearch : IPathfinding
	{
		public override List<T> FindPath<T>(Dictionary<T, Dictionary<T, int>> edges, T originNode, T destinationNode)
		{
			Queue<T> frontier = new Queue<T>();
			frontier.Enqueue(originNode);

			Dictionary<T, T> cameFrom = new Dictionary<T, T>();
			cameFrom.Add(originNode, default(T));

			while (frontier.Count != 0)
			{
				var current = frontier.Dequeue();
				if (current.Equals(destinationNode)) break;

				var neighbours = GetNeigbours(edges, current);
				foreach (var neighbour in neighbours)
				{
					if (!cameFrom.ContainsKey(neighbour))
					{
						cameFrom.Add(neighbour, current);
						frontier.Enqueue(neighbour);
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
	}
}
