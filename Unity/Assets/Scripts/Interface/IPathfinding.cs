using System.Collections.Generic;
using System.Linq;

namespace ProjectZGL
{
	public abstract class IPathfinding
	{
		/// <summary>
		/// 方法查找图中两个节点之间的路径
		/// </summary>
		/// <param name="edges">
		/// Graph edges represented as nested dictionaries. Outer dictionary contains all nodes in the graph, inner dictionary contains 
		/// its neighbouring nodes with edge weight.
		/// </param>
		/// <returns>
		/// 如果存在路径，方法返回路径所包含的节点列表。否则，返回空列表
		/// </returns>
		public abstract List<T> FindPath<T>(Dictionary<T, Dictionary<T, int>> edges, T originNode, T destinationNode) where T : IGraphNode;

		protected List<T> GetNeigbours<T>(Dictionary<T, Dictionary<T, int>> edges, T node) where T : IGraphNode
		{
			if (!edges.ContainsKey(node))
			{
				return new List<T>();
			}
			return edges[node].Keys.ToList();
		}
	}
}
