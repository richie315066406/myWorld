using GameFramework.Event;
using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// CellClicked事件在用户单击Unit时被调用
	/// </summary>
	public class AttackEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(AttackEventArgs).GetHashCode();

		/// <summary>
		/// 初始化用户单击Unit事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public AttackEventArgs(Unit attacker, Unit defender, int damage)
		{
			Attacker = attacker;
			Defender = defender;

			Damage = damage;
		}

		public Unit Attacker
		{
			get;
			private set;
		}

	    public Unit Defender
		{
		    get;
		    private set;
	    }

		public int Damage { get; private set; }

		public override int Id
		{
			get { return EventId; }
		}

		public override void Clear()
        {
	        Attacker = null;
	        Defender = null;
	        Damage = default(int);
		}
	}
}