using System.Collections;
using System.Collections.Generic;
using GameFramework.DataNode;
using GameFramework.DataTable;
using GameFramework.Event;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public class MainForm : CommonForm
    {
        [SerializeField]
        private RectTransform m_Choose = null;
        [SerializeField]
        private Button m_funcButton = null;
        // private ProcedureMain m_ProcedureMain = null;

        // public void OnStartMapButtonClick()
        // {
        //     //TODO 弹出行动地图
        // }

        protected override void OnOpen(object userData)
        {
            GameEntry.Event.Subscribe(GameStateChangeEventArgs.EventId, OnGameStateChange);
            base.OnOpen(userData);
            InstantiateButton();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            //更新当前金钱、时间等信息

            // string moneyText = GameEntry.DataNode.GetData<VarInt>(Constant.PlayerInfo.Money, m_PlayerNode).ToString();
            // int time = GameEntry.DataNode.GetData<VarInt>(Constant.GameInfo.NowTime,m_GameNode);
            // string timeText = TimeUtility.TimeFormat(time);

            // if (string.IsNullOrEmpty(moneyText) || string.IsNullOrEmpty(timeText))
            // {
            //     Log.Error("some date is null！");
            //     return;
            // }

            // m_MoneyText.text = moneyText;
            // m_TimeText.text = timeText;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
        }

        private void InstantiateButton()
        {
            List<int> funcs = GameEntry.DataNode.GetNowSite().FunctionList;

            if (funcs == null)
            {
                Log.Error("funcs is null!!");
            }

            foreach (var func in funcs)
            {
                Button button = Instantiate(m_funcButton);
                if (button == null)
                    Log.Error("FuncButton is null!!!");
                button.transform.SetParent(m_Choose);
                Text buttonName = button.GetComponentInChildren<Text>();
                IDataTable<DRFunction> dtFunction = GameEntry.DataTable.GetDataTable<DRFunction>();
                DRFunction dRFunction = dtFunction.GetDataRow(func);
                buttonName.text = dRFunction.ButtonName;
                Log.Info(func);
                button.onClick.AddListener(delegate ()
                {
                    this.OnClick(dRFunction);
                });
            }
        }
        void OnClick(DRFunction dRFunction)
        {
            GameEntry.Event.Fire(this, new FunctionTriggerEventArgs(dRFunction));
        }

        private void OnGameStateChange(object sender, GameEventArgs e)
        {
            GameStateChangeEventArgs ne = (GameStateChangeEventArgs)e;
            switch (ne.GameState)
            {
                case GameStateType.ActionBegin:
                    //TODO 行动开始：选择行动
                    break;
                case GameStateType.Actioning:
                    //TODO 行动中：进行回合或者取消行动
                    break;
                case GameStateType.ActionEnd:
                    //TODO 行动结束
                    break;
                default:
                    Log.Error("unknow GameState！");
                    break;
            }


        }
    }
}

