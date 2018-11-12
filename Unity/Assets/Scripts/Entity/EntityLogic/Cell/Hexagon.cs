using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 实现六边形Cell
	/// </summary>
	public abstract class Hexagon : Cell
	{
		private HexagonData m_HexagonData = null;
		public HexagonData HexagonData
		{
			get { return m_HexagonData; }
			set { m_HexagonData = value; }
		}

		protected override void OnShow(object userData)
		{
			base.OnShow(userData);
			m_HexagonData = (HexagonData)userData;

//			m_HexagonData.OffsetCoord = new Vector2(Width - j - 1, Height - i - 1);
//			m_HexagonData.OffsetCoord = hexGridType;
			m_HexagonData.MovementCost = 1;
		}

		/// <summary>
		/// 将立方体坐标转换回偏移坐标
		/// </summary>
		/// <param name="cubeCoords">要转换的立方体坐标</param>
		/// <returns>与给定立方体坐标对应的偏移坐标</returns>
		protected Vector2 CubeToOffsetCoords(Vector3 cubeCoords)
		{
			Vector2 ret = new Vector2();

			switch (m_HexagonData.HexGridType)
			{
				case HexGridType.odd_q:
					{
						ret.x = cubeCoords.x;
						ret.y = cubeCoords.z + (cubeCoords.x + (Mathf.Abs(cubeCoords.x) % 2)) / 2;
						break;
					}
				case HexGridType.even_q:
					{
						ret.x = cubeCoords.x;
						ret.y = cubeCoords.z + (cubeCoords.x - (Mathf.Abs(cubeCoords.x) % 2)) / 2;
						break;
					}
			}
			return ret;
		}

		public override int GetDistance(Cell other)
		{
			var _other = other as Hexagon;
			int distance = (int)(Mathf.Abs(m_HexagonData.CubeCoord.x - _other.m_HexagonData.CubeCoord.x) 
			                     + Mathf.Abs(m_HexagonData.CubeCoord.y - _other.m_HexagonData.CubeCoord.y) 
			                     + Mathf.Abs(m_HexagonData.CubeCoord.z - _other.m_HexagonData.CubeCoord.z)) / 2;
			return distance;
		}//距离是用曼哈顿标准给出的

		public override List<Cell> GetNeighbours(List<Cell> cells)
		{
			if (m_HexagonData.Neighbours == null)
			{
				m_HexagonData.Neighbours = new List<Cell>(6);
				foreach (var direction in HexagonData._Directions)
				{
					var neighbour = cells.Find(c => c.CellData.MOffsetCoord == CubeToOffsetCoords(m_HexagonData.CubeCoord + direction));
					if (neighbour == null) continue;
					m_HexagonData.Neighbours.Add(neighbour);
				}
			}
			return m_HexagonData.Neighbours;
		}//每个正方形单元格有6个邻居，它们在网格中相对于单元格的位置以_directions常量存储
	}


}

