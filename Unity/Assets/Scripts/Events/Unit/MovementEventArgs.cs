using GameFramework.Event;
using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// CellClicked事件在用户单击Unit时被调用
	/// </summary>
	public class MovementEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(MovementEventArgs).GetHashCode();

		/// <summary>
		/// 初始化用户单击Unit事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public MovementEventArgs(Cell sourceCell, Cell destinationCell, List<Cell> path)
		{
			OriginCell = sourceCell;
			DestinationCell = destinationCell;
			Path = path;
		}

		public Cell OriginCell
		{
			get;
			private set;
		}

	    public Cell DestinationCell
	    {
		    get;
		    private set;
	    }

		public List<Cell> Path { get; private set; }

		public override int Id
		{
			get { return EventId; }
		}

		public override void Clear()
        {
	        OriginCell = null;
	        DestinationCell = null;
	        Path = null;
		}

	}

}