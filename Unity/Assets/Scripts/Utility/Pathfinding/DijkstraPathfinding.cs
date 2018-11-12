using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// Dijkstra寻路算法的实现
	/// </summary>
	class DijkstraPathfinding : IPathfinding
	{
		public Dictionary<Cell, List<Cell>> findAllPaths(Dictionary<Cell, Dictionary<Cell, int>> edges, Cell originNode)
		{
			IPriorityQueue<Cell> frontier = new HeapPriorityQueue<Cell>();
			frontier.Enqueue(originNode, 0);

			Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell>();
			cameFrom.Add(originNode, default(Cell));
			Dictionary<Cell, int> costSoFar = new Dictionary<Cell, int>();
			costSoFar.Add(originNode, 0);

			while (frontier.Count != 0)
			{
				var current = frontier.Dequeue();
				var neighbours = GetNeigbours(edges, current);
				foreach (var neighbour in neighbours)
				{
					var newCost = costSoFar[current] + edges[current][neighbour];
					if (!costSoFar.ContainsKey(neighbour) || newCost < costSoFar[neighbour])
					{
						costSoFar[neighbour] = newCost;
						cameFrom[neighbour] = current;
						frontier.Enqueue(neighbour, newCost);
					}
				}
			}

			Dictionary<Cell, List<Cell>> paths = new Dictionary<Cell, List<Cell>>();
			foreach (Cell destination in cameFrom.Keys)
			{
				List<Cell> path = new List<Cell>();
				var current = destination;
				while (!current.Equals(originNode))
				{
					path.Add(current);
					current = cameFrom[current];
				}
				paths.Add(destination, path);
			}
			return paths;
		}
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
				var neighbours = GetNeigbours(edges, current);
				foreach (var neighbour in neighbours)
				{
					var newCost = costSoFar[current] + edges[current][neighbour];
					if (!costSoFar.ContainsKey(neighbour) || newCost < costSoFar[neighbour])
					{
						costSoFar[neighbour] = newCost;
						cameFrom[neighbour] = current;
						frontier.Enqueue(neighbour, newCost);
					}
				}
				if (current.Equals(destinationNode)) break;
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
