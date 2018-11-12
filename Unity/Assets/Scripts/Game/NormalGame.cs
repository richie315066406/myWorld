using GameFramework.DataNode;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
	public class NormalGame : GameBase
	{
//		private float m_ElapseSeconds = 0f;
//		private IDataNode m_GameData = null;
//		private IDataNode m_playerData = null;

//		private bool m_GotoShop = false;


		public void GotoShop(){
//			m_GotoShop = true;
		}

		public override void Initialize()
		{
			base.Initialize();
//			Log.Info("Normal Game Initialize!");
//			m_GameData = GameEntry.DataNode.GetOrAddNode("Game");
//			GameEntry.DataNode.SetData<VarInt>(Constant.GameInfo.NowSite, 1, m_GameData);
//			GameEntry.DataNode.SetData<VarInt>(Constant.GameInfo.NowTime, 0, m_GameData);
//			m_playerData = GameEntry.DataNode.GetOrAddNode("PlayerInfo");
//			m_playerData = GameEntry.DataNode.GetOrAddNode(Constant.DataNode.PlayerNode);
//			GameEntry.DataNode.SetData<VarInt>(Constant.PlayerInfo.Money, 100, m_playerData);
		}

		public override void StartGame(){
			base.StartGame();
		}

		public override GameMode GameMode
		{
			get
			{
				return GameMode.Normal;
			}
		}

//		public override void Update(float elapseSeconds, float realElapseSeconds)
//		{
//			base.Update(elapseSeconds, realElapseSeconds);
//
////			if (m_GotoShop)
////			{
////				int nowSite = GameEntry.DataNode.GetData<VarInt>(Constant.GameInfo.NowSite);
////				IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
////				IDataTable<DRShop> dtShop = GameEntry.DataTable.GetDataTable<DRShop>();
////
////				GameEntry.UI.OpenUIForm(UIFormId.ShopForm, this);
////
////			}
//		}
	}
}