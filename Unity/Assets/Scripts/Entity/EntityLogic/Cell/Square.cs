using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 方块单元的实现
	/// </summary>
	public abstract class Square : Cell
	{
		[SerializeField]
		private SquareData m_SquareData = null;

		public SquareData SquareData
		{
			get { return m_SquareData; }
		}

		public override int GetDistance(Cell other)
		{
			return (int)(Mathf.Abs(m_SquareData.MOffsetCoord.x - other.CellData.MOffsetCoord.x) + Mathf.Abs(m_SquareData.MOffsetCoord.y - other.CellData.MOffsetCoord.y));
		}//距离是用曼哈顿标准给出的
		public override List<Cell> GetNeighbours(List<Cell> cells)
		{
			if (m_SquareData.Neighbours == null)
			{
				m_SquareData.Neighbours = new List<Cell>(4);
				foreach (var direction in SquareData._Directions)
				{
					var neighbour = cells.Find(c => c.CellData.MOffsetCoord == m_SquareData.MOffsetCoord + direction);
					if (neighbour == null) continue;

					m_SquareData.Neighbours.Add(neighbour);
				}
			}

			return m_SquareData.Neighbours;
		}
		//每个正方形单元格有四个邻居，它们在网格中相对于单元格的位置以_directions常量存储
		//实现有八个邻居的方块是完全可能的，但是需要修改GetDistance函数
	}

}
