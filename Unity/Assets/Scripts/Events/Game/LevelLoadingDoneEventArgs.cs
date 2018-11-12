using GameFramework.Event;

namespace ProjectZGL
{
	/// <summary>
	/// 回合结束被调用
	/// </summary>
	public class LevelLoadingDoneEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(LevelLoadingDoneEventArgs).GetHashCode();

		/// <summary>
		/// 初始化回合结束事件的新实例。
		/// </summary>
		/// <param name="newHP">单击的单元格</param>
		public LevelLoadingDoneEventArgs()
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