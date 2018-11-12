using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ProjectZGL
{
	public class MyHexagonData : HexagonData
	{
		[SerializeField]
		private GroundType m_GroundType;
		[SerializeField]
		private bool m_IsSkyTaken;//Indicates if a flying unit is occupying the cell.

		public MyHexagonData(int entityId, int typeId)
			: base(entityId, typeId)
		{

		}
		/// <summary>
		/// Ground Type
		/// </summary>
		public GroundType GroundType
		{
			get
			{
				return m_GroundType;
			}

			set
			{
				m_GroundType = value;
			}
		}


		public bool IsSkyTaken
		{
			get
			{
				return m_IsSkyTaken;
			}

			set
			{
				m_IsSkyTaken = value;
			}
		}

	}
}
