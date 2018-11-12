using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectZGL
{
	public class UnitData   :EntityData
	{
		public Dictionary<Cell, List<Cell>> cachedPaths = null;
		
//		public UnitState UnitState { get; set; }

		/// <summary>
		/// 应用于unit的buff集合
		/// </summary>
		public List<Buff> Buffs { get; set; }

		public int TotalHitPoints { get; set; }
		protected int TotalMovementPoints;
		protected int TotalActionPoints;

		/// <summary>
		/// 单元当前占用的单元格
		/// </summary>
		public Cell Cell { get; set; }

		public int HitPoints;
		public int AttackRange;
		public int AttackFactor;
		public int DefenceFactor;
		/// <summary>
		/// 确定单元在网格中的移动距离
		/// </summary>
		public int MovementPoints;
		/// <summary>
		/// 确定运动的速度
		/// </summary>
		public float MovementSpeed;
		/// <summary>
		/// 确定一个回合可以执行多少攻击单位
		/// </summary>
		public int ActionPoints;

		/// <summary>
		/// 表示该单位所属的玩家。
		/// Should correspoond with PlayerNumber variable on Player script.
		/// </summary>
		public int PlayerNumber;

		/// <summary>
		/// 指示运动动画是否正在播放
		/// </summary>
		public bool isMoving { get; set; }

		public UnitData(int entityId, int typeId):base(entityId,typeId)
		{

		}
	}
}
