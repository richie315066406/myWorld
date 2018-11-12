using GameFramework.Event;

namespace ProjectZGL
{

	public class UnitClickedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UnitClickedEventArgs).GetHashCode();

		/// <summary>
		/// unit被点击时调用
		/// </summary>
		/// <param name="unit">被点击unit</param>
		public UnitClickedEventArgs(Unit unit)
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