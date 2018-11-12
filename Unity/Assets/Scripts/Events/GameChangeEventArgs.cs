using GameFramework.Event;

namespace ProjectZGL
{
    /// <summary>
    /// 游戏状态改变事件
    /// </summary>
    public class GameChangeEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(GameChangeEventArgs).GetHashCode();

        /// <summary>
        /// 初始化玩家生命值改变事件的新实例。
        /// </summary>
        /// <param name="newHP">玩家新的生命值。</param>
        public GameChangeEventArgs(GameInfo gameInfo)
        {
            GameInfo = gameInfo;
        }

        /// <summary>
        /// 获取玩家生命值改变事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 玩家新的生命值。
        /// </summary>
        public GameInfo GameInfo
        {
            get;
            private set;
        }

        public override void Clear()
        {
			//            throw new System.NotImplementedException();
	        GameInfo = null;
        }
    }

}