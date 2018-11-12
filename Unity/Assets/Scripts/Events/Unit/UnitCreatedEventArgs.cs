using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// CellClicked事件在用户单击Unit时被调用
	/// </summary>
	public class UnitCreatedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UnitCreatedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化Unit创建事件的新实例。
		/// </summary>
		/// <param name="newHP">创建的unit</param>
		public UnitCreatedEventArgs(Transform unit)
		{
			Unit = unit;
		}

		public Transform Unit
		{
			get;
			private set;
		}

		public override int Id
		{
			get { return EventId; }
		}

		public override void Clear()
        {
	        Unit = null;
		}
	}
}