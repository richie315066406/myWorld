using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	public abstract class HexagonData : CellData
	{
		[SerializeField]
		private List<Cell> m_Neighbours = null;
//		[HideInInspector]
		private HexGridType m_HexGridType;
		public static readonly Vector3[] _Directions =
		{
			new Vector3(+1, -1, 0), new Vector3(+1, 0, -1), new Vector3(0, +1, -1),
			new Vector3(-1, +1, 0), new Vector3(-1, 0, +1), new Vector3(0, -1, +1)
		};

		public HexagonData(int entityId, int typeId) 
			: base(entityId, typeId)
		{

		}

		/// <summary>
		/// 获取所有相邻的Cell
		/// </summary>
		public List<Cell> Neighbours
		{
			get { return m_Neighbours; }
			set { m_Neighbours = value; }
		}
		/// <summary>
		/// hexgrid有四种布局类型
		/// 为了将立方体坐标转换为偏移量，这种区别是必要的，反之亦然
		/// </summary>
		public HexGridType HexGridType
		{
			get { return m_HexGridType; }
			set { m_HexGridType = value; }
		}

		/// <summary>
		/// 将偏移坐标转换为立方体坐标
		/// 立方体坐标是另一个坐标系统，使计算十六进制网格更容易
		/// </summary>
		public Vector3 CubeCoord
		{
			get
			{
				Vector3 ret = new Vector3();
				switch (HexGridType)
				{
					case HexGridType.odd_q:
					{
						ret.x = MOffsetCoord.x;
						ret.z = MOffsetCoord.y - (MOffsetCoord.x + (Mathf.Abs(MOffsetCoord.x) % 2)) / 2;
						ret.y = -ret.x - ret.z;
						break;
					}
					case HexGridType.even_q:
					{
						ret.x = MOffsetCoord.x;
						ret.z = MOffsetCoord.y - (MOffsetCoord.x - (Mathf.Abs(MOffsetCoord.x) % 2)) / 2;
						ret.y = -ret.x - ret.z;
						break;
					}
				}
				return ret;
			}
		}
	}
}
