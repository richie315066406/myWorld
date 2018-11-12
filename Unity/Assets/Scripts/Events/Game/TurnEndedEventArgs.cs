using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// 回合结束被调用
	/// </summary>
	public class TurnEndedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(TurnEndedEventArgs).GetHashCode();

		/// <summary>
		/// 初始化回合结束事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public TurnEndedEventArgs()
        {

        }

		/// <summary>
		/// 获取回合结束事件编号。
		/// </summary>
		public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public override void Clear()
        {

        }
    }

}