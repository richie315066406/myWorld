using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// 当游标退出单元格的collider时，将调用celldehighlight事件
	/// </summary>
	public class CellHighlightedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(CellHighlightedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化游标退出单元格事件的新实例
		/// </summary>
		/// <param name="newHP">退出的单元格</param>
		public CellHighlightedEventArgs(Cell cell)
        {
            Cell = cell;
        }

		/// <summary>
		/// 获取游标退出单元格事件编号
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

		/// <summary>
		/// 游标退出的单元格
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