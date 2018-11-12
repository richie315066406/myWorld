using System;
using UnityEngine;

namespace ProjectZGL{
    [Serializable]
    public class GameInfo{
        [SerializeField]
        private int m_NowSite = 0;
	    [SerializeField]
	    private int m_NowTime = 0;
        private GameStateType m_NowState = GameStateType.ActionBegin;
        
        /// <summary>
        /// 当前地点
        /// </summary>
        public int NowSite
        {
            get
            {
                return m_NowSite;
            }
            set
            {
                m_NowSite = value;
            }
        }

        /// <summary>
        /// 当前时间
        /// </summary>
		public int NowTime
		{
			get
			{
				return m_NowTime;
			}

			set
			{
				m_NowTime = value;
			}
		}

        /// <summary>
        /// 当前状态
        /// </summary>
		public GameStateType Nowstate
		{
			get
			{
				return m_NowState;
			}

			set
			{
				m_NowState = value;
                GameEntry.Event.Fire(this,new GameStateChangeEventArgs(m_NowState));
			}
		}
    }
}