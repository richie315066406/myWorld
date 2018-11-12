using System;
using UnityEngine;

namespace ProjectZGL
{
	public abstract class CellData : EntityData
	{
//		[HideInInspector]
		[SerializeField]
		private Vector2 m_OffsetCoord;
		[SerializeField]
		private bool m_IsTaken;
		[SerializeField]
		private int m_MovementCost;

		public CellData(int entityId, int typeId) 
			: base(entityId, typeId)
		{
			m_IsTaken = false;
		}

		/// <summary>
		/// 单元格在网格上的位置
		/// </summary>
		public Vector2 MOffsetCoord { get { return m_OffsetCoord; } set { m_OffsetCoord = value; } }
		/// <summary>
		/// 指定是否被路障占据
		/// </summary>
		public bool IsTaken
		{
			get
			{
				return m_IsTaken;
			}

			set
			{
				m_IsTaken = value;
			}
		}
		/// <summary>
		/// 通过单元格的移动成本
		/// </summary>
		public int MovementCost
		{
			get
			{
				return m_MovementCost;
			}

			set
			{
				m_MovementCost = value;
			}
		}
	}
}
