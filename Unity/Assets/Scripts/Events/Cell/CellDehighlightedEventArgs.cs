using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// 当游标进入单元格的collider时被调用
	/// </summary>
	public class CellDehighlightedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(CellDehighlightedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化游标进入单元格事件的新实例。
		/// </summary>
		/// <param name="newHP">进入的单元格</param>
		public CellDehighlightedEventArgs(Cell cell)
        {
            Cell = cell;
        }

		/// <summary>
		/// 获取进入的单元格事件编号。
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

		/// <summary>
		/// 进入的单元格
		/// </summary>
		public Cell Cell
		{
            get;
            private set;
        }

        public override void Clear()
        {
	        Cell = null;
        }
    }

}