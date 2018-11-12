using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// ʵ��������Cell
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
		/// ������������ת����ƫ������
		/// </summary>
		/// <param name="cubeCoords">Ҫת��������������</param>
		/// <returns>����������������Ӧ��ƫ������</returns>
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
		}//�������������ٱ�׼������

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
		}//ÿ�������ε�Ԫ����6���ھӣ�����������������ڵ�Ԫ���λ����_directions�����洢
	}


}

