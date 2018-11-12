using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// CellClicked事件在用户单击单元格时被调用
	/// </summary>
	public class CellClickedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(CellClickedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化用户单击单元格事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public CellClickedEventArgs(Cell cell)
        {
            Cell = cell;
        }

		/// <summary>
		/// 获取用户单击单元格事件编号。
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

		/// <summary>
		/// 单击的单元格
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