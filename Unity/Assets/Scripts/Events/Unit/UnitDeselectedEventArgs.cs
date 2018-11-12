using GameFramework.Event;

namespace ProjectZGL
{

	public class UnitDeselectedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UnitDeselectedEventArgs).GetHashCode();

		/// <summary>
		/// 取消选择事件
		/// </summary>
		/// <param name="newHP">取消选择的unit</param>
		public UnitDeselectedEventArgs(Unit unit)
        {
	        Unit = unit;
        }

		/// <summary>
		/// 获取用户取消选择的Unit事件编号。
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

		/// <summary>
		/// 单击的Unit
		/// </summary>
		public Unit Unit
		{
            get;
            private set;
        }

        public override void Clear()
        {
	        Unit = null;
        }
    }

}