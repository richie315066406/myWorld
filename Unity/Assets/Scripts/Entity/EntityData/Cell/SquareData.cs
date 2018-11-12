using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	public class SquareData:CellData
	{
		private List<Cell> m_Neighbours = null;

		public List<Cell> Neighbours
		{
			get { return m_Neighbours; }
			set { m_Neighbours = value; }
		}
		public static readonly Vector2[] _Directions =
		{
			new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1)
		};

		public SquareData(int entityId, int typeId) 
			: base(entityId, typeId)
		{

		}
	}
}
