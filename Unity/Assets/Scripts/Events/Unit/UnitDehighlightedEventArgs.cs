using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// CellClicked事件在用户单击Unit时被调用
	/// </summary>
	public class UnitDehighlightedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UnitDehighlightedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化用户单击Unit事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public UnitDehighlightedEventArgs(Unit unit)
        {
	        Unit = unit;
        }

		/// <summary>
		/// 获取用户单击Unit事件编号。
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