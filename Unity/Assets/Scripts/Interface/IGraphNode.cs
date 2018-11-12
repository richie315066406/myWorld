namespace ProjectZGL
{
	public interface IGraphNode
	{
		/// <summary>
		/// 方法返回作为参数给定的igraph节点的距离 
		/// </summary>
		int GetDistance(IGraphNode other);
	}
}