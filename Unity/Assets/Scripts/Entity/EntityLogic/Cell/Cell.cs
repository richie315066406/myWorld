using UnityEngine;
using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
	/// <summary>
	/// 代表网格上的单个单元格
	/// </summary>
	public abstract class Cell : EntityLogic, IGraphNode, IEquatable<Cell>
	{
		[SerializeField]
		private CellData m_CellData = null;

		public CellData CellData
		{
			get { return m_CellData; }
			set { m_CellData = value; }
		}

		protected override void OnShow(object userData)
		{
			base.OnShow(userData);
//			m_CellData = (Cell) userData;
//			var hexSize = this.GetCellDimensions();
//			GetNeighbours()
//			this.transform.position = new Vector3((m_CellData.Position.y * hexSize.x * 0.75f), 0, (m_CellData.Position.x * hexSize.z) 
//			                                                                                      + (m_CellData.Position.y % 2 == 0 ? 0 : hexSize.z * 0.5f));
		}

		/// <summary>
		/// 方法返回作为参数给定的单元格的距离
		/// </summary>
		public abstract int GetDistance(Cell other);

		/// <summary>
		/// 方法从作为参数的单元格列表中返回当前单元格附近的单元格
		/// </summary>
		public abstract List<Cell> GetNeighbours(List<Cell> cells);

		/// <summary>
		/// 方法返回物理单元格的维数
		/// It is necessary necessary for grid generators
		/// </summary>
		public abstract Vector3 GetCellDimensions();
		
		public int GetDistance(IGraphNode other)
		{
			return GetDistance(other as Cell);
		}

		public bool Equals(Cell other)
		{
			return (m_CellData.MOffsetCoord.x == other.CellData.MOffsetCoord.x && m_CellData.MOffsetCoord.y == other.CellData.MOffsetCoord.y);
		}

		public override bool Equals(object other)
		{
			if (!(other is Cell))
				return false;

			return Equals(other as Cell);
		}

		public override int GetHashCode()
		{
			int hash = 23;

			hash = (hash * 37) + (int)m_CellData.MOffsetCoord.x;
			hash = (hash * 37) + (int)m_CellData.MOffsetCoord.y;
			return hash;

		}

		protected virtual void OnMouseEnter()
		{
			GameEntry.Event.Fire(this, new CellHighlightedEventArgs(this));
		}
		protected virtual void OnMouseExit()
		{
			GameEntry.Event.Fire(this, new CellDehighlightedEventArgs(this));
		}
		protected virtual void OnMouseDown()
		{
			GameEntry.Event.Fire(this, new CellClickedEventArgs(this));
		}
		/// <summary>
		/// 设置Cell颜色
		/// </summary>
		public abstract void SetColor(Color color);
	}
}
