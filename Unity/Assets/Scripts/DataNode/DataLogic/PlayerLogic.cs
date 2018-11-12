using System.Collections.Generic;
using GameFramework.Event;

namespace ProjectZGL
{
    public class PlayerLogic : DataLogicBase
    {
        private PlayerInfo m_PlayerInfo = new PlayerInfo();

        public override void OnInit(object userData)
        {
            m_PlayerInfo = new PlayerInfo()
            {
                Name = "Lee",
                Hp = 100,
                Vigor = 100,
                Money = 100,
                ItemIDs = new List<int>() { 1, 3, 4 },
            };
            GameEntry.DataNode.SetPlayerInfo(m_PlayerInfo);

            GameEntry.Event.Subscribe(PlayerStateChangedEventArgs.EventId, OnPlayerHPChang);
        }

        public override void OnEnter(object userData)
        {
            throw new System.NotImplementedException();
        }

        public override void OnLeave(object userData, bool isShutdown)
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate(object userData, float elapseSeconds, float realElapseSeconds)
        {
            m_PlayerInfo = GameEntry.DataNode.GetPlayerInfo();




        }

        private void OnPlayerHPChang(object sender, GameEventArgs e)
        {
//	        PlayerStateChangedEventArgs ne = e as PlayerStateChangedEventArgs;
//            if (ne.PlayerInfo.Hp <= 0)
//            {
//				//TODO GameOver GameBase.
//
//            }
            // Log.Info("New HP is '{0}'.", ne.NewHP.ToString());
        }
    }


}