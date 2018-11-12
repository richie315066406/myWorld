using GameFramework;
using ProjectZGL;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public class MenuForm : UGuiForm
    {
//        [SerializeField]
//        private GameObject m_QuitButton = null;

        private ProcedureMenu m_ProcedureMenu = null;

        public void OnStartNewGameButtonClick()
        {
            m_ProcedureMenu.StartGame();
        }

	    public void OnLoadGameButtonClick()
	    {
//			m_ProcedureMenu.LoadGame();
	    }

        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
        }

        public void OnAboutButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.AboutForm);
        }

        public void OnQuitButtonClick()
        {
			//TODO 退出按钮点击事件
//            GameEntry.UI.OpenDialog(new DialogParams()
//            {
//                Mode = 2,
//                Title = GameEntry.Localization.GetString("AskQuitGame.Title"),
//                Message = GameEntry.Localization.GetString("AskQuitGame.Message"),
//                OnClickConfirm = delegate (object userData) { GameEntry.Shutdown(ShutdownType.Quit); },
//            });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_ProcedureMenu = (ProcedureMenu)userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }

//            m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
        }

        protected override void OnClose(object userData)
        {
            m_ProcedureMenu = null;

            base.OnClose(userData);
        }
    }
}
