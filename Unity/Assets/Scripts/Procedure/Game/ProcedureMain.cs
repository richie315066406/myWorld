using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
	public abstract class ProcedureMain : ProcedureBase
    {
        private const float GameOverDelayedSeconds = 2f;

        private bool m_GotoStart = false;

	    private bool m_ChangeSite = false;
	    private int m_SiteId = 0;


		private MainForm m_MainForm = null;

        private float m_GotoMenuDelaySeconds = 0f;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        public void GotoStart()
        {
            m_GotoStart = true;
        }
	    public void ChangeSite(int siteId)
	    {
		    m_ChangeSite = true;
		    m_SiteId = siteId;
	    }


        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            //监听UI开启事件
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
	        GameEntry.Event.Subscribe(FunctionTriggerEventArgs.EventId, OnFunctionTrigger);
			//游标 进入、退出及点击事件
			GameEntry.Event.Subscribe(CellClickedEventArgs.EventId,OnCellClicked);
	        GameEntry.Event.Subscribe(CellDehighlightedEventArgs.EventId, OnCellDeselected);
	        GameEntry.Event.Subscribe(CellHighlightedEventArgs.EventId, OnCellSelected);

			//界面上需要显示的按钮ID
			// int siteId = GameEntry.DataNode.GetData<VarInt>(Constant.GameInfo.NowSite, m_GameData);
			// IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
			// DRSite drSite = dtSite.GetDataRow(siteId);

	        //			if (CellGridComponent.Units.Select(u => u.PlayerNumber).Distinct().ToList().Count == 1)
	        //			{
	        //				CellGridComponent.CellGridState = new CellGridStateGameOver(CellGridComponent);
	        //			}

			//打开主界面
//			GameEntry.UI.OpenUIForm(UIFormId.MainForm, this);

            m_GotoStart = false;

            // int[] buttons = drSite.FunctionList;
            //	        procedureOwner.SetData<Var>();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
	        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
	        GameEntry.Event.Unsubscribe(FunctionTriggerEventArgs.EventId, OnFunctionTrigger);

	        //游标 进入、退出及点击事件
	        GameEntry.Event.Unsubscribe(CellClickedEventArgs.EventId, OnCellClicked);
	        GameEntry.Event.Unsubscribe(CellDehighlightedEventArgs.EventId, OnCellDeselected);
	        GameEntry.Event.Unsubscribe(CellHighlightedEventArgs.EventId, OnCellSelected);

			base.OnLeave(procedureOwner, isShutdown);
        }

	    protected override void OnDestroy(ProcedureOwner procedureOwner)
	    {
		    base.OnDestroy(procedureOwner);
	    }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MainForm = (MainForm)ne.UIForm.Logic;
        }

	    private void OnFunctionTrigger(object sender, GameEventArgs e)
	    {
		    FunctionTriggerEventArgs ne = (FunctionTriggerEventArgs) e;
		    switch (ne.DRFunction.FunctionType)
		    {
				case (int)FunctionType.ChangeScene:
				    // m_ProcedureMain.ChangeSite(dRFunction.ParameterList[1]);
				    Log.Info("FuncitonType 1");
				    break;
			    case (int)FunctionType.OpenShop:
				    //TODO 打开商店界面
				    //					GameEntry.UI.OpenUIForm()
				    Log.Info("FuncitonType 2");
				    break;
			    case 3:
				    Log.Info("FuncitonType 3");
				    break;
			    case 4:
				    Log.Info("FuncitonType 4");
				    break;
			    default:
				    Log.Error("unknown FuncitonType!");
				    break;
			}

	    }

	    protected virtual void OnCellClicked(object sender, GameEventArgs e) { }
	    protected virtual void OnCellDeselected(object sender, GameEventArgs e) { }
	    protected virtual void OnCellSelected(object sender, GameEventArgs e) { }
	}
}
