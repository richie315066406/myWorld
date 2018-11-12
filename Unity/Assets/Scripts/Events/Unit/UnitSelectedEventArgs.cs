using GameFramework.Event;

namespace ProjectZGL
{

	public class UnitSelectedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UnitSelectedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化用户选中的Unit事件的新实例。
		/// </summary>
		/// <param name="newHP">选中的单元格</param>
		public UnitSelectedEventArgs(Unit unit)
        {
	        Unit = unit;
        }

		/// <summary>
		/// 获取用户选中的Unit事件编号。
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

		/// <summary>
		/// 选中的Unit
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