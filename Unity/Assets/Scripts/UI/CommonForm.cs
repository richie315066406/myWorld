using System.Collections.Generic;
using GameFramework.Event;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectZGL
{
    public class CommonForm : UGuiForm
    {
        [SerializeField]
        private Text m_MoneyText = null;
        [SerializeField]
        private Text m_TimeText = null;

        [SerializeField]
        private Image m_BackgroundImage = null;
        [SerializeField]
        private Text m_SiteNameText = null;
//        [SerializeField]
//        private Sprite[] s_BGImages = null;

        private static List<Sprite> m_BgImageList = new List<Sprite>();
	    public static void AddBgImage(Sprite asset)
	    {
			m_BgImageList.Add(asset);
	    }

        public void OnLButtonClick()
        {
			GameEntry.UI.OpenUIForm(UIFormId.KnapsackForm);
		}
	    public void OnMButtonClick()
	    {
		    //TODO 中间按钮点击
	    }
		public void OnRButtonClick()
        {
	        //TODO 弹出手机界面
		}

		protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            //开启事件监听
            GameEntry.Event.Subscribe(GameChangeEventArgs.EventId, OnGameChange);
            GameEntry.Event.Subscribe(PlayerStateChangedEventArgs.EventId, OnPlayerStateChange);

            //引用初始化
            // m_ProcedureMain = (ProcedureMain)userData;
//	        if (m_SiteNameText!=null)
//	        {
//		        m_SiteNameText.gameObject.SetActive(false);
//			}

			//改变背景图
			//	        GameEntry.Resource.LoadBackground(GameEntry.DataNode.GetNowSite().BGAssName);
			//	        m_BackgroundImage.sprite = s_BGImage;
			foreach (var sprite in m_BgImageList)
            {
                if (sprite.name == GameEntry.DataNode.GetNowSite().BGAssName)
                {
                    m_BackgroundImage.sprite = sprite;
                }
            }

            if (m_BackgroundImage.sprite == null)
            {
                //显示文字
                m_SiteNameText.gameObject.SetActive(true);
                m_SiteNameText.text = GameEntry.DataNode.GetNowSite().BGAssName;
                m_SiteNameText.gameObject.SetActive(false);
            }
            //改变音乐

            //顶部信息显示
            m_MoneyText.text = GameEntry.DataNode.GetPlayerInfo().Money.ToString();
            m_TimeText.text = TimeUtility.TimeFormat(GameEntry.DataNode.GetNowTime());

            //	        IDataTable<DRFunction> dtFunction = GameEntry.DataTable.GetDataTable<DRFunction>();
            // int[] functionList = m_MainParams.FunctionList;

            // foreach (var function in functionList)
            // {
            // 	DRFunction drFunction = dtFunction.GetDataRow(function);

            // }
            //			m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
        }

        protected override void OnClose(object userData)
        {
			//关闭监听事件
	        GameEntry.Event.Unsubscribe(GameChangeEventArgs.EventId, OnGameChange);
	        GameEntry.Event.Unsubscribe(PlayerStateChangedEventArgs.EventId, OnPlayerStateChange);
            base.OnClose(userData);
        }

        //游戏信息改变事件响应函数
        private void OnGameChange(object sender, GameEventArgs e)
        {
            GameChangeEventArgs ne = (GameChangeEventArgs)e;
            m_TimeText.text = TimeUtility.TimeFormat(ne.GameInfo.NowTime);
        }

        //玩家状态改变事件响应函数
        private void OnPlayerStateChange(object sender, GameEventArgs e)
        {
            PlayerStateChangedEventArgs ne = (PlayerStateChangedEventArgs)e;
            m_MoneyText.text = ne.PlayerInfo.Money.ToString();
        }


    }

}